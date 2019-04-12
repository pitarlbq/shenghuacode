
using System;

namespace Foresight.DataAccess.Framework
{
	/// <summary>
	/// A custom EntityException class that has a reference to the Entity causing the exception
	/// </summary>
    public class EntityException : System.Exception
    {
        private EntityBaseReadOnly _entity;
		/// <summary>
		/// The entity causing the exception
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
		/// Public constructor 
		/// </summary>
        public EntityException() : base() { }
		
		/// <summary>
		/// Public constructor 
		/// </summary>
        public EntityException(string message) : base(message) { }
		
		/// <summary>
		/// Public constructor 
		/// </summary>
        public EntityException(string message, Exception innerException) : base(message, innerException) { }
		
		/// <summary>
		/// Public constructor taking the entity and a helper
		/// </summary>
        public EntityException(EntityBaseReadOnly entity, SqlHelper helper) : this()
        {
            this._entity = entity;
			this._helper = helper;
        }
		
		/// <summary>
		/// Public constructor taking the entity and a helper
		/// </summary>
        public EntityException(string message, EntityBaseReadOnly entity, SqlHelper helper) : this(message)
        {
            this._entity = entity;
			this._helper = helper;
        }
		
		/// <summary>
		/// Public constructor taking the entity and a helper
		/// </summary>
        public EntityException(string message, Exception innerException, EntityBaseReadOnly entity, SqlHelper helper) : this(message, innerException)
        {
            this._entity = entity;
			this._helper = helper;
        }

		/// <summary>
		/// Public constructor taking the entity 
		/// </summary>
        public EntityException(EntityBaseReadOnly entity) : this()
        {
            this._entity = entity;
        }
		
		/// <summary>
		/// Public constructor taking the entity 
		/// </summary>
        public EntityException(string message, EntityBaseReadOnly entity) : this(message)
        {
            this._entity = entity;
        }
		
		/// <summary>
		/// Public constructor taking the entity 
		/// </summary>
        public EntityException(string message, Exception innerException, EntityBaseReadOnly entity) : this(message, innerException)
        {
            this._entity = entity;
        }
    }
}
