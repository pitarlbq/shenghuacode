
using System;

namespace Foresight.DataAccess.Framework
{
	/// <summary>
	/// A custom CancelEntityEventArgs class that has a reference to the Entity firing the event. 
	/// This EventArgs class allows for the event to be canceled.
	/// </summary>
    public class EntityCancelEventArgs : System.ComponentModel.CancelEventArgs
    {
        private EntityBaseReadOnly _entity;
		/// <summary>
		/// The entity firing the event
		/// </summary>
        public EntityBaseReadOnly Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }
		
		private SqlHelper _helper;
		/// <summary>
		///	The current Sql helper. This allows data access in an event to participate 
		/// in the same transaction as the object firing the event.
		/// </summary>
		public SqlHelper Helper
		{
			get { return _helper; }
			set { _helper = value; }
		}

		/// <summary>
		/// Public constructor taking the entity and a helper
		/// </summary>
        public EntityCancelEventArgs(EntityBaseReadOnly entity, SqlHelper helper)
        {
            this._entity = entity;
			this._helper = helper;
        }
		
		/// <summary>
		/// Public constructor taking the entity
		/// </summary>
		public EntityCancelEventArgs(EntityBaseReadOnly entity)
		{
			this._entity = entity;
		}
    }
}
