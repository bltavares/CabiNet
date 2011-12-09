
Now you need to reference de dll under References on Solution Explorer and add the files generated on the project (Shift + Alt + A).

You may want to use it to generete de tables on the first run also:

Banco db = new Banco();

db.ExecuteNonQuery((new Vendedor).GenerateCreateSQL());

db.ExecuteNonQuery((new Venda).GenerateCreateSQL());

db.ExecuteNonQuery((new Item).GenerateCreateSQL());

db.ExecuteNonQuery((new Produto).GenerateCreateSQL());


