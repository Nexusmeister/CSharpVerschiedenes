insert into TestTable (Test) values (8)

declare @z int = 0

while @z < 100
begin
	insert into TestTable (Test) values (@z)
	set @z = @z + 1
end

select * from TestTable