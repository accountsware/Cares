﻿using System;

namespace Cares.Models.DomainModels
{
    /// <summary>
    /// Business Parnter Individual Domain Model
    /// </summary>
    public class BusinessPartnerIndividual
    {
        #region Persisted Properties

        /// <summary>
        /// Business Partner Id
        /// </summary>
        public long BusinessPartnerId { get; set; }

        /// <summary>
        /// Individual First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Individual Middle Name
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Individual Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Individual Initials
        /// </summary>
        public string Initials { get; set; }

        /// <summary>
        /// Individual License Number
        /// </summary>
        public string LiscenseNumber { get; set; }

        /// <summary>
        /// Individual License Expiry Date
        /// </summary>
        public DateTime? LiscenseExpiryDate { get; set; }

        /// <summary>
        /// Individual Gender Status
        /// </summary>
        public string GenderStatus { get; set; }

        /// <summary>
        /// Individual Passport Number
        /// </summary>
        public string PassportNumber { get; set; }

        /// <summary>
        /// Individual NIC Number
        /// </summary>
        public string NicNumber { get; set; }

        /// <summary>
        /// Individual Marital Status Code
        /// </summary>
        public string MaritalStatusCode { get; set; }

        /// <summary>
        /// Tax Registration Code
        /// </summary>
        public string TaxRegisterationCode { get; set; }

        /// <summary>
        /// Tax Number
        /// </summary>
        public string TaxNumber { get; set; }

        /// <summary>
        /// Date of birth
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Individual Occupation Type Id
        /// </summary>
        public short? OccupationTypeId { get; set; }

        /// <summary>
        /// Individual Is Company External
        /// </summary>
        public bool IsCompanyExternal { get; set; }

        /// <summary>
        /// Individual Company Name
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Individual Company Address
        /// </summary>
        public string CompanyAddress { get; set; }

        /// <summary>
        /// Inidividual Company Phone
        /// </summary>
        public string CompanyPhone { get; set; }

        /// <summary>
        /// Individual Business Partner Company Id
        /// </summary>
        public long? BusinessPartnerCompanyId { get; set; }

        /// <summary>
        /// Row Version
        /// </summary>
        public long RowVersion { get; set; }

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
        public String RecLastUpdatedBy { get; set; }

        /// <summary>
        /// Individual Nic Expiry date
        /// </summary>
        public DateTime? NicExpiryDate { get; set; }

        /// <summary>
        /// Individual Passport Expiry date
        /// </summary>
        public DateTime? PassportExpiryDate { get; set; }

        /// <summary>
        /// User Domain Key
        /// </summary>
        public long UserDomainKey { get; set; }

        /// <summary>
        /// Individual Passport Country Id
        /// </summary>
        public short? PassportCountryId { get; set; }

        /// <summary>
        /// Individual Iqama No
        /// </summary>
        public String IqamaNo { get; set; }

        /// <summary>
        /// Inidividual Iqama expiry date
        /// </summary>
        public DateTime? IqamaExpiryDate { get; set; }

        #endregion

        #region Reference Properties

        /// <summary>
        /// Occupation Type
        /// </summary>
        public virtual OccupationType OccupationType { get; set; }

        /// <summary>
        /// Business Partner Company
        /// </summary>
        public virtual BusinessPartnerCompany BusinessPartnerCompany { get; set; }

        /// <summary>
        /// Passport Country
        /// </summary>
        public virtual Country PassportCountry { get; set; }

        /// <summary>
        /// Business Partner
        /// </summary>
        public virtual BusinessPartner BusinessPartner { get; set; }


        #endregion
    }
}
