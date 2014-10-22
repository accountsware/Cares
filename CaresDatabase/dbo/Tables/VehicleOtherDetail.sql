﻿CREATE TABLE [dbo].[VehicleOtherDetail] (
    [VehicleID]           BIGINT         NOT NULL,
    [NumberOfDoors]       SMALLINT       NULL,
    [HorsePower_CC]       SMALLINT       NOT NULL,
    [NumberOfCylinders]   SMALLINT       NULL,
    [isAlloyRim]          BIT            NULL,
    [ChasisNumber]        NVARCHAR (50)  NOT NULL,
    [EngineNumber]        NVARCHAR (50)  NULL,
    [KeyCode]             NVARCHAR (50)  NULL,
    [RadioCode]           NVARCHAR (50)  NULL,
    [Accessories]         NVARCHAR (500) NULL,
    [TopSpeed]            SMALLINT       NULL,
    [InteriorDescription] NVARCHAR (500) NULL,
    [FrontWheelSize]      FLOAT (53)     NULL,
    [BackWheelSize]       FLOAT (53)     NULL,
    [RecCreatedDt]        DATETIME       NOT NULL,
    [RecCreatedBy]        NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]    DATETIME       NOT NULL,
    [RecLastUpdatedBy]    NVARCHAR (100) NOT NULL,
    [RowVersion]          BIGINT         NOT NULL,
    [IsActive]            BIT            NOT NULL,
    [IsDeleted]           BIT            NOT NULL,
    [IsReadOnly]          BIT            NOT NULL,
    [IsPrivate]           BIT            NOT NULL,
    [UserDomainKey]       BIGINT         NOT NULL,
    CONSTRAINT [PK146] PRIMARY KEY NONCLUSTERED ([VehicleID] ASC),
    CONSTRAINT [RefVehicle327] FOREIGN KEY ([VehicleID]) REFERENCES [dbo].[Vehicle] ([VehicleID]) ON DELETE CASCADE
);



