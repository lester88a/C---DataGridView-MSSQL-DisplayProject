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

-----------for AGING section
select COUNT(A.AGING) as '1 Day' from (select TOP 1000 RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' and Warranty = 1 AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868') and (Status != 'X' and Status != 'C'and Status != 'E' and Status != 'I' and Status != 'B') group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn
) A where A.AGING =1

select COUNT(A.AGING) as '2 Days' from (select TOP 1000 RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' and Warranty = 1 AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868') and (Status != 'X' and Status != 'C'and Status != 'E' and Status != 'I' and Status != 'B') group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn
) A where A.AGING =2

select COUNT(A.AGING) as '3 Days' from (select TOP 1000 RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' and Warranty = 1 AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868') and (Status != 'X' and Status != 'C'and Status != 'E' and Status != 'I' and Status != 'B') group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn
) A where A.AGING =3

select COUNT(A.AGING) as '4 Days' from (select TOP 1000 RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' and Warranty = 1 AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868') and (Status != 'X' and Status != 'C'and Status != 'E' and Status != 'I' and Status != 'B') group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn
) A where A.AGING =4

select COUNT(A.AGING) as '5 Days' from (select TOP 1000 RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' and Warranty = 1 AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868') and (Status != 'X' and Status != 'C'and Status != 'E' and Status != 'I' and Status != 'B') group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn
) A where A.AGING =5

select COUNT(A.AGING) as '6 Days' from (select TOP 1000 RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' and Warranty = 1 AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868') and (Status != 'X' and Status != 'C'and Status != 'E' and Status != 'I' and Status != 'B') group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn
) A where A.AGING =6

select COUNT(A.AGING) as '>=7 Days' from (select TOP 1000 RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' and Warranty = 1 AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868') and (Status != 'X' and Status != 'C'and Status != 'E' and Status != 'I' and Status != 'B') group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn
) A where A.AGING >=7
-------------works for AGING setion
select
    FirstSet.Day1,
	SecondSet.Day2,
	ThirdSet.Day3,
	Four.Day4,
	Five.Day5,
	Six.Day6,
	Seven.Day7
from (select COUNT(Day1.AGING) as Day1 from (select TOP 1000 RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' and Warranty = 1 AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868') and (Status != 'X' and Status != 'C'and Status != 'E' and Status != 'I' and Status != 'B') group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn
) Day1 where Day1.AGING =1) as FirstSet
inner join
(select COUNT(Day2.AGING) as Day2 from (select TOP 1000 RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' and Warranty = 1 AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868') and (Status != 'X' and Status != 'C'and Status != 'E' and Status != 'I' and Status != 'B') group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn
) Day2 where Day2.AGING =2) as SecondSet
on FirstSet.Day1 != SecondSet.Day2
inner join
(select COUNT(Day3.AGING) as Day3 from (select TOP 1000 RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' and Warranty = 1 AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868') and (Status != 'X' and Status != 'C'and Status != 'E' and Status != 'I' and Status != 'B') group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn
) Day3 where Day3.AGING =3) as ThirdSet
on SecondSet.Day2 != ThirdSet.Day3
inner join
(select COUNT(Day4.AGING) as Day4 from (select TOP 1000 RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' and Warranty = 1 AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868') and (Status != 'X' and Status != 'C'and Status != 'E' and Status != 'I' and Status != 'B') group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn
) Day4 where Day4.AGING =3) as Four
on FirstSet.Day1 != SecondSet.Day2
inner join
(select COUNT(Day5.AGING) as Day5 from (select TOP 1000 RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' and Warranty = 1 AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868') and (Status != 'X' and Status != 'C'and Status != 'E' and Status != 'I' and Status != 'B') group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn
) Day5 where Day5.AGING =5) as Five
on FirstSet.Day1 != SecondSet.Day2
inner join
(select COUNT(Day6.AGING) as Day6 from (select TOP 1000 RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' and Warranty = 1 AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868') and (Status != 'X' and Status != 'C'and Status != 'E' and Status != 'I' and Status != 'B') group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn
) Day6 where Day6.AGING =6) as Six
on FirstSet.Day1 != SecondSet.Day2
inner join
(select COUNT(Day7.AGING) as Day7 from (select TOP 1000 RefNumber as Ref#, convert(varchar(6),DateIn,107) as DateIn,FuturetelLocation as Location, DATEDIFF(day, DateIn, convert(date, GETDATE())) as AGING, LastTechnician as Technician from tblRepair where DateIn between convert(date,DATEADD(day,-60,GETDATE())) and convert(date, GETDATE()) and LastTechnician != '' and Manufacturer = 'SAMSUNG' and Warranty = 1 AND (SVP != 'KCC' AND SVP != 'TCC' AND SVP != 'KXREPAIR' AND SVP != 'TXREPAIR') and (DealerID != '7398' and DealerID != '7430'  and DealerID != '7432' and DealerID != '7481' and DealerID != '7482' and DealerID != '7498' and DealerID != '7550' and DealerID != '7552' and DealerID != '7551' and DealerID != '2911' and DealerID != '132' and DealerID != '6868') and (Status != 'X' and Status != 'C'and Status != 'E' and Status != 'I' and Status != 'B') group by RefNumber, DateIn, LastTechnician, FuturetelLocation order by LastTechnician ASC, AGING DESC, DateIn
) Day7 where Day7.AGING >=7) as Seven
on FirstSet.Day1 != SecondSet.Day2
