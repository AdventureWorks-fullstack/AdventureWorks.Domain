--INSERT INTO Production.Location (Name) VALUES ('Webshop Warehouse');

DECLARE @MyCursor CURSOR;
DECLARE @MyField number;
BEGIN
    SET @MyCursor = CURSOR FOR
    select top 1000 YourField from Prod
        where StatusID = 7

    OPEN @MyCursor
    FETCH NEXT FROM @MyCursor
    INTO @MyField

    WHILE @@FETCH_STATUS = 0
    BEGIN
      /*
         YOUR ALGORITHM GOES HERE
      */
      FETCH NEXT FROM @MyCursor
      INTO @MyField
    END;

    CLOSE @MyCursor ;
    DEALLOCATE @MyCursor;
END;