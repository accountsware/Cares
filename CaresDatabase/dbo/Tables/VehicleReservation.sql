﻿CREATE TABLE [dbo].[VehicleReservation] (
    [VehicleReservationID]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [StartDtTime]                   DATETIME       NOT NULL,
    [EndDtTime]                     DATETIME       NOT NULL,
    [BookingMainID]                 BIGINT         NULL,
    [VehicleID]                     BIGINT         NOT NULL,
    [RAMainID]                      BIGINT         NULL,
    [VehicleReservationDescription] NVARCHAR (500) NULL,
    [RowVersion]                    BIGINT         CONSTRAINT [DF__VehicleRe__RowVe__2630A1B7] DEFAULT ((0)) NOT NULL,
    [IsActive]                      BIT            CONSTRAINT [DF__VehicleRe__IsAct__2724C5F0] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                     BIT            CONSTRAINT [DF__VehicleRe__IsDel__2818EA29] DEFAULT ((0)) NOT NULL,
    [IsPrivate]                     BIT            CONSTRAINT [DF__VehicleRe__IsPri__290D0E62] DEFAULT ((0)) NOT NULL,
    [IsReadOnly]                    BIT            CONSTRAINT [DF__VehicleRe__IsRea__2A01329B] DEFAULT ((0)) NOT NULL,
    [RecCreatedDt]                  DATETIME       NOT NULL,
    [RecCreatedBy]                  NVARCHAR (100) NOT NULL,
    [RecLastUpdatedDt]              DATETIME       NOT NULL,
    [RecLastUpdatedBy]              NVARCHAR (100) NOT NULL,
    [NRTMainID]                     BIGINT         NULL,
    [UserDomainKey]                 BIGINT         NOT NULL,
    CONSTRAINT [PK89_1_2_2] PRIMARY KEY NONCLUSTERED ([VehicleReservationID] ASC),
    CONSTRAINT [RefBookingMain510] FOREIGN KEY ([BookingMainID]) REFERENCES [dbo].[BookingMain] ([BookingMainID]),
    CONSTRAINT [RefNRTMain584] FOREIGN KEY ([NRTMainID]) REFERENCES [dbo].[NRTMain] ([NRTMainID]),
    CONSTRAINT [RefRAMain512] FOREIGN KEY ([RAMainID]) REFERENCES [dbo].[RAMain] ([RAMainID]),
    CONSTRAINT [RefVehicle509] FOREIGN KEY ([VehicleID]) REFERENCES [dbo].[Vehicle] ([VehicleID]) ON DELETE CASCADE
);



