# SOLID

- **SRP** - Один из самых популярных принципов программирования. Часто толкуется по разному. В общем и целом не должно быть такого, что классы из разных слоев абстракций или из разных уровней бизнес-логики влияли друг на друга.
- **OCP** - Очень важно отметить, что класс должен быть закрыт в том числе из-за тестов. Они ведь уже написаны, и мы должны гарантировать, что они не начнут падать. Единственная гарантия этого - расширять класс(и писать новые тесты), а не менять его. Есть множество причин помимо этого(пересборка и поставка, обратная совместимость), но тесты почему-то часто упускают.
    
    
- **LSP** - Невероятно важный принцип, с которым мы сталкиваемся на ежедневной основе. Редко вижу, чтобы он нарушался.
- **ISP** - Очень простой, но эффективный принцип, много не скажешь.
- **DIP -** высокоуровневые модули не должны зависеть от низкоуровневых. Вместо этого высокоуровневые модули должны зависеть от абстракций, чтобы изменения/подмена в коде низкого уровня не влияла на высокий уровень.