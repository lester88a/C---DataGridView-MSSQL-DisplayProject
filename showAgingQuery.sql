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