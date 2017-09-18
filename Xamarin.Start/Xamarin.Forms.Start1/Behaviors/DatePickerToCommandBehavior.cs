using System;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xamarin.Forms.Start1.Behaviors {
	public class DatePickerToCommandBehavior : BehaviorBase<DatePicker> {
		Delegate eventHandler;

		public static readonly BindableProperty EventNameProperty = BindableProperty.Create(nameof(EventName), typeof(string), typeof(EventToCommandBehavior), null, propertyChanged: OnEventNameChanged);
		public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(EventToCommandBehavior), null);

		public string EventName {
			get { return (string)GetValue(EventNameProperty); }
			set { SetValue(EventNameProperty, value); }
		}

		public ICommand Command {
			get { return (ICommand)GetValue(CommandProperty); }
			set { SetValue(CommandProperty, value); }
		}

		private void DeregisterEvent(string name) {
			if(string.IsNullOrWhiteSpace(name)) {
				return;
			}

			if(eventHandler == null) {
				return;
			}
			EventInfo eventInfo = AssociatedObject.GetType().GetRuntimeEvent(name);
			if(eventInfo == null) {
				throw new ArgumentException(string.Format("EventToCommandBehavior: Can't de-register the '{0}' event.", EventName));
			}
			eventInfo.RemoveEventHandler(AssociatedObject, eventHandler);
			eventHandler = null;
		}

		protected override void OnAttachedTo(DatePicker bindable) {
			base.OnAttachedTo(bindable);
			RegisterEvent(EventName);
		}

		protected override void OnDetachingFrom(DatePicker bindable) {
			DeregisterEvent(EventName);
			base.OnDetachingFrom(bindable);
		}

		private void RegisterEvent(string name) {
			if(string.IsNullOrWhiteSpace(name)) {
				return;
			}

			EventInfo eventInfo = AssociatedObject.GetType().GetRuntimeEvent(name);
			if(eventInfo == null) {
				throw new ArgumentException(string.Format("EventToCommandBehavior: Can't register the '{0}' event.", EventName));
			}
			MethodInfo methodInfo = typeof(DatePickerToCommandBehavior).GetTypeInfo().GetDeclaredMethod("OnEvent");
			eventHandler = methodInfo.CreateDelegate(eventInfo.EventHandlerType, this);
			eventInfo.AddEventHandler(AssociatedObject, eventHandler);
		}

		private void OnEvent(object sender, object eventArgs) {
			if(Command == null) {
				return;
			}

			var datePicker = (DatePicker)sender;
			if(datePicker == null)
				return;

			if(Command.CanExecute(datePicker.Date)) {
				Command.Execute(datePicker.Date);
			}
		}

		private static void OnEventNameChanged(BindableObject bindable, object oldValue, object newValue) {
			var behavior = (DatePickerToCommandBehavior)bindable;
			if(behavior.AssociatedObject == null) {
				return;
			}

			string oldEventName = (string)oldValue;
			string newEventName = (string)newValue;

			behavior.DeregisterEvent(oldEventName);
			behavior.RegisterEvent(newEventName);
		}
	}
}
