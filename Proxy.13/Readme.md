﻿# Proxy

- Суть паттерна в том, чтобы предоставить какой-то интерфейс к определенному ресурсу. Обычно за этим интерфейсом скрывается доп. функционал доступа к ресурсу, например ленивая инициализация, проверка доступа, кэширование, логирование и т.д.
- Существует множество разновидностей паттерна посредник, но в целом они все сводятся к одному - добавление промежуточного функционала некому объекту. Такой middleware по сути