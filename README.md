# Battleship
Консольный Морской бой,написанный с помощью OpenGL.
	Game – содержит статический метод Main, который является точкой начала выполнения программы.
	ScreensManager – содержит все игровые экраны и методы управления отрисовкой этих экранов.
	FieldScreen – определяет основной игровой экран, на котором размещаются все игровые сущности, содержит методы отрисовки и инициализации поля. Так же содержит 5 объектов класса MenuItem, отвечающих за расстановку кораблей и удаление флота.
	HelpScreen – содержит информацию об управлении в игре и объект класса MenuItem, позволяющий скрывать отображение этой информации на экране.
	DefeatScreen – содержит информацию о поражении, предлагает сыграть еще раз или выйти из игры. Содержит 3 объекта класса MenuItem, позволяющие выбрать сыграть еще раз или выйти из игры соответственно. 
	WinScreen – содержит информацию о победе, предлагает сыграть еще раз или выйти из игры. Содержит 2 объекта класса MenuItem, позволяющие выбрать сыграть еще раз или выйти из игры соответственно. 
	NavyFormedScreen – содержит информацию о том, что сформирован флот игрока, так же содержит объект класса MenuItem, позволяющий закрыть это окно и вернуться в игру. 
	ShipSunkingScreen – содержит информацию о том, потоплен корабль противника, так же содержит объект класса MenuItem, позволяющий закрыть это окно и вернуться в игру. 
	MainScreen – определяет фон главного меню и 3 объекта класса MenuItem, позволяющие переключиться на основной игровой экран, экран справки или выйти из игры.
	Square – определяет клетку (часть игрового поля, занятая или не занятая кораблем).
	Ship – определяет сам корабль и методы формирования каждого из четырех видов кораблей.
	Navy – определяет флот (набор кораблей), содержит методы формирования флота.
	Shooting – содержит методы, определяющие выстрел игрока и последовательность выстрелов противника. 
	GameEngine – определяет весь игровой процесс, содержит методы отрисовки кораблей.
	MenuItem – определяет пункт меню, содержит текст в виде объекта класса TextRenderer, методы отрисовки и определения активности на основе положения курсора, событие нажатия левой кнопки мыши.
	CursorLoader – содержит статический метод Load для загрузки курсора.
	TextRenderer – определяет строку текста для вывода на экран и содержит метод отрисовки этого текста.
	TextureLoader – содержит информацию о текстуре и загружает её из файла с помощью статического метода Load.
