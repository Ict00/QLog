# EN
QLog is very simple logging library. Nothing more than logging. Here is how you use it:
1. Init logger
```cs
Logger.Init(new LoggerSettings
{
    logToConsole = true,
    filePath = "file.log"
});
```
2. Use
```cs
// Sender Type is optional
Logger.Info("Info", SenderType);
Logger.Info<Sender>("Info");
Logger.Warn("Warn", SenderType);
Logger.Warn<Sender>("Warn");
Logger.Error(new Exception("Some Exception"), SenderType);
Logger.Error<Sender>(new Exception("Some Exception"));
Logger.Stop(); // To stop logging
```
# RU
QLog - это очень простая библиотека для логирования. Ничего большего, чем логгинг. Вот как это использовать:
1. Инициализировать логгер
```cs
Logger.Init(new LoggerSettings
{
    logToConsole = true,
    filePath = "файл.log"
});
```
2. Use
```cs
// Тип Объекта Отправителя опционален
Logger.Info("Информация", ТипОбъектаОтправителя);
Logger.Info<Объект-Отправитель>("Информация");
Logger.Warn("Предупреждение", ТипОбъектаОтправителя);
Logger.Warn<Объект-Отправитель>("Предупреждение");
Logger.Error(new Exception("Исключение"), ТипОбъектаОтправителя);
Logger.Error<Объект-Отправитель>(new Exception("Исключение"));
Logger.Stop(); // Для остановки логгинга
```
