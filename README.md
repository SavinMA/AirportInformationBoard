# AirportInformationBoard
Информационное табло аэропорта

Создать приложение для отображения информации о работе аэропорта.

Из текстового файла загрузить расписание рейсов.
Расписание содержит информацию о
 - типе самолёта (*)
 - вылет/прилёт
 - времени вылета/прилёта
 - городе (куда вылетел/откуда прилетел)

(*) Тип самолёта определяет его максимальную вместимость,
фактическое количество пассажиров определяется случайным образом в процессе работы приложения.

При старте приложения начинается имитация работы аэропорта, согласно расписания.
Скорость имитации задается множителем (от x1 до x10000).
Скорость имитации можно изменять во время работы приложения.

Интерфейс приложения.

Сверху - Строка информации о последнем рейсе.

Основная область (слева) - Количество пассажиров (Прилёт)
 - в последнем рейсе
 - за последние 24 часа
 - сумма за всё время работы

Основная область (справа) - Количество пассажиров (Вылет)
 - в последнем рейсе
 - за последние 24 часа
 - сумма за всё время работы

Снизу - Гистограмма (прилёт/вылет) за последние 24 часа (накопление за 1 час).

Каждое изменение информации должно быть анимировано и привлекать внимание.
