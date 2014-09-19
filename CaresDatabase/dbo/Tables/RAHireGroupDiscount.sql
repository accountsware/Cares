﻿CREATE TABLE [dbo].[RAHireGroupDiscount] (
    [RAHireGroupDiscountID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [RAHireGroupDiscountDescription] NVARCHAR (500) NULL,
    [RAHireGroupID]                  BIGINT         NOT NULL,
    [StartDtTime]                    DATETIME       NOT NULL,
    [EndDtTime]                      DATETIME       NOT NULL,
    [DiscountPerc]                   FLOAT (53)     NOT NULL,
    [DiscountAmount]                 FLOAT (53)     CONSTRAINT [DF__RAHireGro__Disco__1446FBA6] DEFAULT ((0)) NOT NULL,
    [DiscountDays]                   INT            NOT NULL,
    [DiscountHours]                  INT            NOT NULL,
    [DiscountMinutes]                INT            NOT NULL,
    [TariffType]                     NVARCHAR (100) NOT NULL,
    [DiscountCode]                   NVARCHAR (100) NOT NULL,
    [DiscountKey]                    SMALLINT       NOT NULL,
    [RowVersion]                     BIGINT         CONSTRAINT [DF__RAHireGro__RowVe__153B1FDF] DEFAULT ((0)) NOT NULL,
    [IsActive]                       BIT            CONSTRAINT [DF__RAHireGro__IsAct__162F4418] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                      BIT            CONSTRAINT [DF__RAHireGro__IsDel__17236851] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                      BIT            CONSTRAINT [DF__RAHireGro__IsPri__18178C8A] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]                     BIT            CONSTRAINT [DF__RAHireGro__IsRea__190BB0C3] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]                   DATETIME       NOT NULL,
    [RecCreatedBy]                   NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]               DATETIME       NOT NULL,
    [RecLastUpdatedBy]               NVARCHAR (100) NOT NULL,
    [UserDomainKey]                  BIGINT         NOT NULL,
    CONSTRAINT [PK126_2_4_1] PRIMARY KEY NONCLUSTERED ([RAHireGroupDiscountID] ASC),
    CONSTRAINT [RefRAHireGroup602] FOREIGN KEY ([RAHireGroupID]) REFERENCES [dbo].[RAHireGroup] ([RAHireGroupID])
);
