﻿
using System;
using System.Collections.Generic;
using System.Text;

namespace Foresight.DataAccess.Framework
{
    /// <summary>
    /// An error for a validation 
    /// </summary>
    [Serializable()]
    public class ValidationError
    {
        private string _errorMessage;
        /// <summary>
        /// The error message for the validation exception
        /// </summary>
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        private EntityBase _entity;
        /// <summary>
        /// The entity that is invalid
        /// </summary>
        public EntityBase Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }

        private string _validationGroup;
        /// <summary>
        /// The ruleset that was violated
        /// </summary>
        public string ValidationGroup
        {
            get { return _validationGroup; }
            set { _validationGroup = value; }
        }

        private string _propertyName;
        /// <summary>
        /// The property that is invalid
        /// </summary>
        public string PropertyName
        {
            get { return _propertyName; }
            set { _propertyName = value; }
        }

        /// <summary>
        /// Initializes a new instance of the ValidationError class.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="entity">The invalid entity.</param>
        /// <param name="property">The invalid property.</param>
        public ValidationError(string errorMessage, EntityBase entity, string propertyName)
        {
            _errorMessage = errorMessage;
            _entity = entity;
            _propertyName = propertyName;
        }
		
		/// <summary>
        /// Initializes a new instance of the ValidationError class.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="entity">The invalid entity.</param>
        /// <param name="property">The invalid property.</param>
		/// <param name="validationGroup">The validation group this error violates.</param>
        public ValidationError(string errorMessage, EntityBase entity, string propertyName, string validationGroup)
        {
            _errorMessage = errorMessage;
            _entity = entity;
            _propertyName = propertyName;
			_validationGroup = validationGroup;
        }
    }
}
