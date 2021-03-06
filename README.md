Электронная версия игры "Монополия"
===================

Проект является компьютерной адаптацией популярной настольной игры **"Монополия"**. В проекте сохранены все основные правила оригинальной игры. Основной паттерн  - **MVVM** (WPF)


Ссылка на GitHub
-------------
https://github.com/beheltcarrot/Team_Project_Monopoly

Участники Проекта
-------------
- Коробин Сергей - **GUI**,

- Зубайдуллин Ринат - **Основная логика**,

- Умеренков Даниил - **Стуктура MVVM**

Схема приложения
-------------
- Logic.DataProcess - Библиотека, отвечающая за основную логику
	- Models (Папка) - Модели всех объектов
		- Cards - Модели краточек ("Шанс", "Общественная казна")
			- Card - Базовая модель карточки
		- Cells - Модель клетки
			- Cell - Базовая модель клетки
			- Property - Модель собственности
		- User - Информация об одном пользователе
		- Monopoly - Информация о возможных монополиях
	- GameEngine - Класс, содержащий основную логику (Методы хода, покупки и т.д.)
	- Session - Информация о нынешней сессии (Количество пользователей)
	- Repository - Класс, являющийся звязующим звеном между ядром и кодом представления
- Logic.UI - Библиотека, отвечающая за ViewModel'и
	- ViewModel (Папка)
		- ViewModelLocator - Отвечает за статическое представление остальные ViewModel'ей в системе
		- MainViewModel - ViewModel главного окна игры
		- StartWindowModel - ViewModel экрана запуска
- UI_Main - Запускаемый проект WPF
	- MainWindow.xaml - Главный экран игры
	- StartWindow - Экран запуска игры
- UI_TestConsole - Консольное приложение, используемое для дебага
	- Program - Основной класс UI_Testconsole

Интерфейс
-------------
Стартовое окно
![](https://pp.vk.me/c637817/v637817712/21618/-tz8y7CyFwQ.jpg)

Основное окно
![](https://pp.vk.me/c637817/v637817712/21621/rANxZ1bAfqo.jpg)
