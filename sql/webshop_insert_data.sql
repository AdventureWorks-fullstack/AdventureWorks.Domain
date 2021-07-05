DECLARE @MyCursor CURSOR;
DECLARE @MyField int;
DECLARE @LocationId smallint;

BEGIN
    SET @LocationId = 61
    SET @MyCursor = CURSOR FOR
    SELECT ProductID FROM Production.Product
        -- where StatusID = 7

    OPEN @MyCursor
    FETCH NEXT FROM @MyCursor
    INTO @MyField

    WHILE @@FETCH_STATUS = 0
    BEGIN
        INSERT INTO Production.ProductInventory(ProductID, LocationID, Quantity, Shelf, Bin) VALUES (@MyField, @LocationId, 1, 'N/A', 0)
      FETCH NEXT FROM @MyCursor
      INTO @MyField
    END;

    CLOSE @MyCursor ;
    DEALLOCATE @MyCursor;
END;