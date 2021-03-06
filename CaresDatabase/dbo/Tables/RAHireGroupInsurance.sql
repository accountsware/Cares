﻿CREATE TABLE [dbo].[RAHireGroupInsurance] (
    [RAHireGroupInsuranceID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [InsuranceTypeID]                 SMALLINT       NOT NULL,
    [RAHireGroupID]                   BIGINT         NOT NULL,
    [RAHireGroupInsuranceDescription] NVARCHAR (500) NULL,
    [StartDtTime]                     DATETIME       NOT NULL,
    [EndDtTime]                       DATETIME       NOT NULL,
    [InsuranceRate]                   FLOAT (53)     NOT NULL,
    [InsuranceCharge]                 FLOAT (53)     NOT NULL,
    [ChargedDay]                      INT            NOT NULL,
    [ChargedHour]                     INT            NOT NULL,
    [ChargedMinute]                   INT            NOT NULL,
    [TariffType]                      NVARCHAR (355) NOT NULL,
    [RowVersion]                      BIGINT         CONSTRAINT [DF__RAHireGro__RowVe__23150941] DEFAULT ((0)) NOT NULL,
    [IsActive]                        BIT            CONSTRAINT [DF__RAHireGro__IsAct__24092D7A] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                       BIT            CONSTRAINT [DF__RAHireGro__IsDel__24FD51B3] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                       BIT            CONSTRAINT [DF__RAHireGro__IsPri__25F175EC] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]                      BIT            CONSTRAINT [DF__RAHireGro__IsRea__26E59A25] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]                    DATETIME       NOT NULL,
    [RecCreatedBy]                    NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]                DATETIME       NOT NULL,
    [RecLastUpdatedBy]                NVARCHAR (100) NOT NULL,
    [UserDomainKey]                   BIGINT         NOT NULL,
    CONSTRAINT [PK126_1_1_2] PRIMARY KEY NONCLUSTERED ([RAHireGroupInsuranceID] ASC),
    CONSTRAINT [RefInsuranceType526] FOREIGN KEY ([InsuranceTypeID]) REFERENCES [dbo].[InsuranceType] ([InsuranceTypeID]),
    CONSTRAINT [RefRAHireGroup527] FOREIGN KEY ([RAHireGroupID]) REFERENCES [dbo].[RAHireGroup] ([RAHireGroupID])
);

