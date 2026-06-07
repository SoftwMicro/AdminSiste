validar Cole o código exatamente assim e aperte Enter:

C# Todos Validos
ModelState.Where(ms => ms.Value.Errors.Count == 0).Select(ms => ms.Key).ToList()

Lista de todos atribuitos não validos

ModelState.Where(ms => ms.Value.Errors.Count > 0).Select(ms => ms.Key).ToList()
