
using System;

namespace Foresight.DataAccess.Framework
{
	/// <summary>
	/// A custom EntityEventArgs class that has a reference to the Entity firing the event
	/// </summary>
    public class EntityValidationCancelEventArgs : EntityCancelEventArgs
    {
		private string _validationGroup;
		/// <summary>
		/// The validation group that is being validated.
		/// </summary>
		public string ValidationGroup
		{
			get { return _validationGroup; }
		}
		
		private string _propertyName;
		/// <summary>
		/// The property that is being validated.
		/// </summary>
		public string PropertyName
		{
			get { return _propertyName; }
		}
		
		/// <summary>
		/// Public constructor taking the entity and a helper
		/// </summary>
        public EntityValidationCancelEventArgs(EntityBase entity, string propertyName, string validationGroup) : base(entity)
        {
			this._propertyName = propertyName;
			this._validationGroup = validationGroup;
        }
		
		/// <summary>
		/// Public constructor taking the entity and a helper
		/// </summary>
        public EntityValidationCancelEventArgs(EntityBase entity, SqlHelper helper, string propertyName, string validationGroup) : base(entity, helper)
        {
			this._propertyName = propertyName;
			this._validationGroup = validationGroup;
        }

		/// <summary>
		/// Public constructor taking the entity
		/// </summary>
        public EntityValidationCancelEventArgs(EntityBase entity) : base(entity) { }

		/// <summary>
		/// Public constructor taking the entity and the helper
		/// </summary>
        public EntityValidationCancelEventArgs(EntityBase entity, SqlHelper helper) : base(entity, helper) { }
    }
}
