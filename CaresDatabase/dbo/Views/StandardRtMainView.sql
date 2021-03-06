﻿
CREATE VIEW [dbo].[StandardRtMainView]
AS
select DISTINCT SM.StandardRtMainID,SM.StandardRtMainCode,SM.TariffTypeCode,SM.StandardRtMainName,
      SM.StandardRtMainDescription,SM.StartDt,SM.EndDt,SM.RowVersion,SM.IsActive,SM.IsDeleted,
      SM.IsPrivate,SM.IsReadOnly,SM.RecCreatedDt,SM.RecLastUpdatedDt,SM.RecCreatedBy,
      SM.RecLastUpdatedBy,
TT.TariffTypeCode+'-'+TT.TariffTypeName TariffTypeCodeName,
O.OperationCode+'-'+O.OperationName OperationCodeName,
D.DepartmentCode+'-'+D.DepartmentName DepartmentCodeName,
C.CompanyCode+'-'+C.CompanyName CompanyCodeName,
TT.TariffTypeName,O.OperationID,D.DepartmentID,C.CompanyID


from StandardRtMain SM
inner join TariffType TT on SM.TariffTypeCode=TT.TariffTypeCode
inner join Operation O on TT.OperationID=O.OperationID
inner join Department D on D.DepartmentID=O.DepartmentID
inner join Company C on  C.CompanyID=D.CompanyID
where SM.ISDeleted=0