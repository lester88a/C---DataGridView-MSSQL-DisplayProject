select RefNumber, convert(date,DateIn) as DateIn, Manufacturer,FuturetelLocation, DATEDIFF(day, DateIn, convert(date, GETDATE())) as Aging, LastTechnician
from tblRepair
where DateIn between '20160510' and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' 
AND (SVP != 'KCC' AND SVP != 'TCC') and (DealerID != '7398' and DealerID != '7430' 
and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' 
and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' 
and DealerID != '7551' and DealerID != '2911' and DealerID != '132' 
and DealerID != '6868') and (Status != 'X' and Status != 'C'and Status != 'I') 
group by RefNumber, DateIn, LastTechnician, Manufacturer, FuturetelLocation
order by DateIn, FuturetelLocation, Aging DESC


select RefNumber, convert(date,DateIn) as DateIn, Manufacturer,FuturetelLocation, DATEDIFF(day, DateIn, convert(date, GETDATE())) as 
Aging, LastTechnician from tblRepair where DateIn between '20160510' and convert(date, GETDATE()) and LastTechnician != '' and 
Manufacturer = 'SAMSUNG'  group by RefNumber, DateIn, LastTechnician, Manufacturer, FuturetelLocation order by DateIn, 
FuturetelLocation, Aging DESC




------------------------------------ for priority devices
select RefNumber as Ref#, convert(date,DateIn) as DateIn,FuturetelLocation as Location, DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician from tblRepair where DateIn between convert(date,DATEADD(day,-30,GETDATE())) and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' AND (SVP != 'KCC' AND SVP != 'TCC') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868') and (Status != 'X' and Status != 'C'and Status != 'I') group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by DateIn, FuturetelLocation, AGING DESC               




------------for tech total output

SELECT tblUser.FirstName + ' ' + tblUser.LastName as Technician, count(tblUser.FirstName + tblUser.LastName) as Total

FROM EasyDB.dbo.tblRepair JOIN EasyDB.dbo.tblUser ON tblRepair.LastTechnician = tblUser.UserName 

WHERE tblRepair.Manufacturer = 'SAMSUNG' AND (tblRepair.DateFinish >= '05/17/2016 08:00:00' AND tblRepair.DateFinish < '05/17/2016 10:00:00') AND (tblRepair.SVP <> 'KCC' AND tblRepair.SVP <> 'TCC') and (tblRepair.DealerID <> '7398' and tblRepair.DealerID <> '7430' and tblRepair.DealerID <> '7432' and tblRepair.DealerID <> '7481' and tblRepair.DealerID <> '7482' and tblRepair.DealerID <> '7498' and tblRepair.DealerID <> '7550' and tblRepair.DealerID <> '7552' and tblRepair.DealerID <> '7551' and tblRepair.DealerID <> '2911' and tblRepair.DealerID <> '132' and tblRepair.DealerID <> '6868') and (tblRepair.Status <> 'X') GROUP BY tblUser.FirstName, tblUser.LastName ORDER BY Total DESC