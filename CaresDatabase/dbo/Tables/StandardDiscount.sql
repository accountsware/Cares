﻿CREATE TABLE [dbo].[StandardDiscount] (
    [StandardDiscountID]      BIGINT         IDENTITY (1, 1) NOT NULL,
    [StandardDiscountMainID]  BIGINT         NOT NULL,
    [ChildStandardDiscountID] BIGINT         NULL,
    [RoleID]                  BIGINT         NULL,
    [OperationsWorkplaceID]   BIGINT         NULL,
    [BPRatingTypeID]          SMALLINT       NULL,
    [VehicleModelID]          SMALLINT       NULL,
    [VehicleCategoryID]       SMALLINT       NULL,
    [VehicleMakeID]           SMALLINT       NULL,
    [HireGroupID]             BIGINT         NULL,
    [CustomerType]            SMALLINT       NOT NULL,
    [ModelYear]               INT            NULL,
    [DiscountPerc]            FLOAT (53)     NOT NULL,
    [StandardDiscountStartDt] DATETIME       NOT NULL,
    [StandardDiscountEndDt]   DATETIME       NOT NULL,
    [RevisionNumber]          BIGINT         NOT NULL,
    [IsActive]                BIT            NOT NULL,
    [IsDeleted]               BIT            NOT NULL,
    [IsPrivate]               BIT            NOT NULL,
    [IsReadOnly]              BIT            NOT NULL,
    [RowVersion]              BIGINT         NOT NULL,
    [RecCreatedDt]            DATETIME       NOT NULL,
    [RecLastUpdatedDt]        DATETIME       NOT NULL,
    [RecCreatedBy]            NVARCHAR (100) NOT NULL,
    [RecLastUpdatedBy]        NVARCHAR (100) NOT NULL,
    [UserDomainKey]           BIGINT         NOT NULL,
    CONSTRAINT [PK80_2_1] PRIMARY KEY NONCLUSTERED ([StandardDiscountID] ASC),
    CONSTRAINT [RefBPRatingType559] FOREIGN KEY ([BPRatingTypeID]) REFERENCES [dbo].[BPRatingType] ([BPRatingTypeID]),
    CONSTRAINT [RefHireGroup576] FOREIGN KEY ([HireGroupID]) REFERENCES [dbo].[HireGroup] ([HireGroupID]),
    CONSTRAINT [RefOperationsWorkplace558] FOREIGN KEY ([OperationsWorkplaceID]) REFERENCES [dbo].[OperationsWorkplace] ([OperationsWorkplaceID]),
    CONSTRAINT [RefRole561] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Role] ([RoleID]),
    CONSTRAINT [RefStandardDiscount557] FOREIGN KEY ([ChildStandardDiscountID]) REFERENCES [dbo].[StandardDiscount] ([StandardDiscountID]),
    CONSTRAINT [RefStandardDiscountMain556] FOREIGN KEY ([StandardDiscountMainID]) REFERENCES [dbo].[StandardDiscountMain] ([StandardDiscountMainID]),
    CONSTRAINT [RefVehicleCategory566] FOREIGN KEY ([VehicleCategoryID]) REFERENCES [dbo].[VehicleCategory] ([VehicleCategoryID]),
    CONSTRAINT [RefVehicleMake567] FOREIGN KEY ([VehicleMakeID]) REFERENCES [dbo].[VehicleMake] ([VehicleMakeID]),
    CONSTRAINT [RefVehicleModel565] FOREIGN KEY ([VehicleModelID]) REFERENCES [dbo].[VehicleModel] ([VehicleModelID])
);
