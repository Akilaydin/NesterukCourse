# Memento

- Суть паттерна в том, чтобы создать механизм, позволяющий установить систему в определенное состояние, которое было запомнено ранее
- Сочетается с паттерном Command
- Базовый пример - Undo/Redo, Git
- Достичь эффекта можно несколькими способами:
    1. Запоминать состояние системы целиком, и когда требуется возврат к нему, восстанавливать без промежуточных шагов
    2. Запоминать действия, которые производятся в системе. Когда требуется восстановить систему до определенного состояния происходит ряд действий undo одно за другим