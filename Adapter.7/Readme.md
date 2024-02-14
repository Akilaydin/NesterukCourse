# Adapter

- Хороший, полезный паттерн. Применяется для конвертации одного интерфейса в другой. Как, например, переходники от зарядок или розеток
- В целом принцип работы тривиальный - нужно знать текущиее API и API, которое должно быть. Адаптер будет так или иначе конвертировать одно в другое
- В некоторых случаях(например, в математике или в Game Loop в играх), есть риск сильно просесть по производительности, если очень часто аллоцировать адаптер на одни и те же данные. В таких случаях хорошим решением будет добавить кэширование