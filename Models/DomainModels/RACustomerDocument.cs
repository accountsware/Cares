﻿using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// RA Customer Document Model
    /// </summary>
    public class RaCustomerDocument
    {
        #region Persisted Properties
        
        /// <summary>
        /// RaAdditionalCharge ID
        /// </summary>
        public long RaCustomerDocumentId { get; set; }

        /// <summary>
        /// Ra Customer Document Description
        /// </summary>
        public string RaCustomerDocumentDescription { get; set; }

        /// <summary>
        /// RA Main Id
        /// </summary>
        public long RaMainId { get; set; }

        /// <summary>
        /// Document Id
        /// </summary>
        public int DocumentId { get; set; }
        
        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }

        /// <summary>
        /// Is Active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Is Deleted
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Is Private
        /// </summary>
        public bool IsPrivate { get; set; }

        /// <summary>
        /// Is Readonly
        /// </summary>
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// Record Created Date
        /// </summary>
        public DateTime RecCreatedDt { get; set; }

        /// <summary>
        /// Record Created By
        /// </summary>
        public string RecCreatedBy { get; set; }

        /// <summary>
        /// Record Last Updated Date
        /// </summary>
        public DateTime RecLastUpdatedDt { get; set; }

        /// <summary>
        /// Record Last Updated By
        /// </summary>
        public string RecLastUpdatedBy { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Ra Main
        /// </summary>
        public virtual RaMain RaMain { get; set; }

        /// <summary>
        /// Document
        /// </summary>
        public virtual Document Document { get; set; }

        #endregion
    }
}
