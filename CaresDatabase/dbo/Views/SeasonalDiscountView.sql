﻿
--select * from SeasonalDiscountMain
CREATE view [dbo].[SeasonalDiscountView]
as
select SD.*,
SDM.TariffTypeCode,SDM.SeasonalDiscountMainCode,SDM.SeasonalDiscountMainName,
SDM.StartDt,SDM.EndDt,
OWP.LocationCode,
VM.VehicleMakeCode +'-'+VM.VehicleMakeName VehicleMakeCodeName,
BRT.BPRatingTypeCode+'-'+BRT.BPRatingTypeName BPRatingTypeCodeName,
VC.VehicleCategoryCode+'-'+VC.VehicleCategoryName VehicleCategoryCodeName,
VMO.VehicleModelCode+'-'+VMO.VehicleModelName VehicleModelCodeName,
HG.HireGroupCode+'-'+HG.HireGroupName HireGroupCodeName

from SeasonalDiscount SD
inner join SeasonalDiscountMain SDM on SDM.SeasonalDiscountMainID=SD.SeasonalDiscountMainID
left outer join OperationsWorkPlace OWP on SD.OperationsWorkPlaceID=OWP.OperationsWorkPlaceID
left outer join VehicleMake VM on VM.VehicleMakeID = SD.VehicleMakeID
left outer join BPRatingType BRT on BRT.BPRatingTypeID= SD.BPRatingTypeID
left outer join VehicleCategory VC on VC.VehicleCategoryID= SD.VehicleCategoryID
left outer join VehicleModel VMO on VMO.VehicleModelID = SD.VehicleModelID
left outer join HireGroup HG on HG.HireGroupID=SD.HireGroupID
where SD.IsDeleted=0 and SD.ChildSeasonalDiscountID is null and SDM.IsDeleted=0