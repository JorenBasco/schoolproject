use master
go
drop database CeruleanProject3
go
create database CeruleanProject3
go

use CeruleanProject3
go


--== table for Users ==--
create table tbUser
(
	userID int identity primary key,
	userEmail varchar(40),
	userPass varchar(30),
	securityLevel varchar(10)
)

--== insert to table Users ==--
insert into tbUser (userEmail,userPass,securityLevel) values
('Joren@mail.com','word','Admin')
--== END of User Table info ==--

--== table for CustomerInfo ==--
create table tbCustomer
(
	custID int identity primary key,
	userID int foreign key references tbUser(userID),
	firstName varchar(30),
	lastName varchar(30),
	phone varchar(30),
	address varchar(40)
)
--== Insert for table Customer ==--
insert into tbCustomer (userID,firstName,lastName,phone,address) values
(1,'Joren','Basco','123-4567','123 fake ave') -- idk but the identity started at 1 and not at 0

--== End of Table customer ==--


--== table for Items ==--
create table tbItems
(
	itemID int identity primary key,
	itemName varchar(50),
	itemDescription varchar(300),
	itemPrice decimal(16,2),
	itemGenre varchar(100),
	itemImg varchar(500),
	itemStock int
)

--== Insert to table Items ==--
insert into tbItems (itemName,itemDescription,itemPrice,itemGenre,itemImg,itemStock) values -- Add Img Source--
('Cool Black Circle Tee','Become Legendary in this Official Tempo Storm Tee with Circle Logo!',25.00,'Clothing/Shirt','TempoShirtBlk.jpg',100),
('Tempo Storm Jersey','The Official Tempo Jersey is handmade in the United States.',60.00,'Clothing/Jersey','TempoJersey.jpg',40),
('Tempo Storm Hoodie','The Official Tempo Storm Zip-Up Team Hoodie is handmade in the United States.',70.00,'Clothing/Hoodie','TempoHoodie.jpg',10),
('Tempo  Bracelet','Make your accessories legendary with the official Tempo Storm Bracelet!',12.00,'Accessory/Bracelet','TempoBracelet.jpg',50),
('Burnt White Circle Tee','Become Legendary in this Official Tempo Storm Tee with Circle Logo!',25.00,'Clothing/Shirt','TempoShirt.jpg',100),
('Tempo Storm Mouse Pad','Become Legendary with the Official Tempo Storm Mousepad',19.99,'Accessory/MousePad','TempoMousePad.jpg',100),
('Legendary Black Tee','This premium fitted short sleeve will fit in every Legends\''s wardrobe. A classic and soft choice.',25.00,'Clothing/Shirt','TempoLegendaryBLK.png',100),
('Tempo Snapback','Is your headwear game feeling less than legendary?  Change that with the Tempo Storm Snapback!',30.00,'Accessory/Headgear','TempoHat.jpg',100),
('Tempo Circle Raglan','Go for a casual look with this Tempo Storm Tri-Blend Raglan!',25.00,'Clothing/Raglan','TempoRaglan.jpg',30),
('Legendary White Tee','This premium fitted short sleeve will fit in every Legends\''s wardrobe. A classic and soft choice.',25.00,'Clothing/Shirt','TempoLegendaryWHT.png',100),
('Tempo Storm Lanyard','Go to your next convention in style with the Premium Tempo Storm Lanyard',9.00,'Accessory/Lanyard','TempoLanyard.jpg',100)


--('Dark Souls 3','Death so many death. sorrry, not sorry, Git Gud kid',79.99,'Action/Adventure/RPG','DarkSouls3.jpg',10),
--('Dishonoured 2','Dishonour on you, Dishonour on your dad, now there is 2 of you',79.99,'Action/Adventure','Dishonoured2.jpg',30),
--('The Last Guardian','a giant bird dog mouse thing follows you, idk',79.99,'Action/Adventure','TheLastGuardian.jpg',60),
--('Uncharted 4','Wow more treasures to find, Nolan North pls stop',79.99,'Action/Adventure','Uncharted4.jpg',23),
--('Watch Dogs 2','the hacking continues, now in san fran.',79.99,'Action/Adventure','WatchDogs2.jpg',100),
--('Dragonball Xenoverse 2','Dragon ball, create your own hero and fight along side Goku and his friends',69.99,'Action/Fighting','Dragonball-xenoverse2.jpg',120),
--('Naruto Shippuden: Ultimate Ninja Storm 4','Be a ninja, fight some ninja, be the very best, Hokage up big boi',79.99,'Fighting','NarutoShippuden.png',104),
--('One Piece: Burning Blood','Be a pirate, fight more pirates be the very best, King of the Pirates',39.99,'Fighting','OnePieceBurningBlood.jpg',100),
--('Street Fighter V','Fight some people in the streets, Pick any country, fight in their streets',24.99,'Fighting','StreetFighterV.jpg',100),
--('The King of Fighers XIV','Fight people, dominate them, become their king',54.99,'Fighting','KingofFigher.jpg',100),
--('F1™ 2016','Create your own legend in F1™ 2016. Get ready to go deeper in the world of the most prestigious motorsport than ever before',59.99,'Racing','F1-2016.jpg',100),
--('Forza Horizon 3','You are in change of the Horizon Festival. Customize everything, hire and fire your friends.Explore Australia in over 350 cars',49.99,'Racing','ForzaHorizon3.jpg',100),
--('TrackMania Turbo','Create your own crazy tracks and share them with players from all over the world!',29.99,'Racing','TrackManiaTurbo.jpg',100),
--('Battlefield 1','Experience the dawn of all-out war only in Battlefield™ 1',79.99,'Action/Shooter','BattlefieldUno.jpg',100),
--('Call of Duty: Infinite Warfare','will take players on an unforgettable journey as they engage in battles from Earth to beyond our atmosphere.',79.99,'Action/Shooter','CallofDuty.jpg',100),
--('Gears Of War 4','a new installment to Gears of War™, follow JD Fenix to find answers about the Locusts',49.99,'Action/Shooter','GearsOfWer4.jpg',100),
--('Overwatch','Clash around the globe on the battlefrields of tomorrow in Overwatch',69.99,'Shooter','Overwetch.jpg',100),
--('Titanfall 2','Pilot and Titan unite as never before, kill your enemies',79.99,'Action/Adventure/Shooter','Titanfell2.jpg',100),
--('FIFA 17','Take to the pitch as your favorite team or start your own professional career in FIFA 17.',79.99,'Sports','Fifa17.jpg',100),
--('Madden 17','Take your team all the way in Madden NFL 17 with new and immersive features in the deepest Franchise mode to-date',69.99,'Sports','Madden17.jpg',100),
--('NBA 2k17','Take your team all the way in NBA 2k17 with new and immersive features',59.99,'Sports','nba2k17.jpg',100),
--('NHL 17','Hit the ice, push the pace, and compete for the Cup in NHL 17',79.99,'Sports','NHL17.jpg',100),
--('Steep','Steep is a new breed of Open world action sports game developed by Ubisoft Annecy',69.99,'Action/Adventure/Sports','Steep.jpg',100),
--('Inside','Hunted and alone, a boy finds himself drawn into the center of a dark project',19.99,'Adventure/Puzzle','Inside.jpg',100),
--('Superhot','SUPERHOT is the first person shooter where time moves only when you move.',24.99,'Shooter/Puzzle','SuperHot.jpg',100),
--('The Witness','Explore and solve puzzles and mysteries of the world',39.99,'Adventure/Puzzle','The-Witness.jpg',100),
--('Civilization® VI','Sid Meier''s Civilization VI is a turn-based 4X video game and the sixth main title in the Civilization series.',59.99,'Strategy','Civ6.jpg',100),
--('Darkest Dungeon','Darkest Dungeon is a challenging gothic roguelike turn-based RPG about the psychological stresses of adventuring.',24.99,'Adventure/RPG/Strategy','DankestDungeon.jpg',100),
--('Stellaris','Explore a vast galaxy full of wonder! ',39.99,'Action/Adventure/Strategy','Stellaris.jpg',100),
--('Total War: Warhammer','combines a turn-based campaign of empire-building with real-time battles, set in the world of Warhammer Fantasy Battles',59.99,'Strategy','TotalWar.jpg',100),
--('XCOM 2','XCOM 2 is a turn-based strategy game sequel to XCOM: Enemy Unknown by Firaxis Games',59.99,'Strategy','X-Com2.jpg',100),
--('Deus Ex: Mankind Dided','Deus Ex: Mankind Divided is an action role-playing video game developed by Eidos Montréal',59.99,'Action/RPG','DeusEx.jpg',100),
--('Final Fantasy XV','Final Fantasy XV is an open world action role-playing video game developed and published by Square Enix',54.99,'Action/Adventure/RPG','ffXV.jpg',100),
--('Hyper Light Drifter','Hyper Light Drifter is a 2D Action RPG in the vein of the best 8-bit and 16-bit classics, with modernized mechanics and designs on a much grander scale.',19.99,'Action/RPG','HyperLightDrifter.jpg',100),
--('The Division','The Division takes place in New York three weeks after a lethal virus, released on Black Friday, has swept through the city.',49.99,'Action/RPG/Shooter','TheDivision.jpg',100),
--('Tales of Berseria',' Follow Velvet Crowe as she embarks on a journey of vengence for what has happen to her and her family',49.99,'RPG','Berseria.jpg',100)

--select*from tbItems where itemGenre like '%Sh%'

--== TABLE CART == --
create table tbCart
(
	cartID int identity primary key,
	userID int foreign key references tbUser(userID),
	itemID int foreign key references tbItems(itemID),
	quantity int
)


create table tbOrder
(
	orderID int identity primary key,
	userID int foreign key references tbUser(userID),
	orderDate date,
	total decimal(16,2)

)

create table tbOrderItems
(
	orderItemID int identity primary key,
	orderID int foreign key references tbOrder(orderID),
	itemID int foreign key references tbItems(itemID),
	quantity int
)

--== PROCs For table Item Info ==--
go
create proc spUser
(
	@userID int = null,
	@userEmail varchar(40)= null,
	@userPass varchar(30) = null,
	@securityLevel varchar(10) = null,
	@newPass varchar(30) = null,
	@action varchar(1) --(C)reate,(R)ead,(U)pdate,(D)elete
)
as begin
	if @action = 'C'
		begin		
			insert into tbUser (userEmail,userPass,securityLevel) values
					   (@userEmail,@userPass,@securityLevel)
			select @@IDENTITY as userID
		end
	else if @action = 'R'
		begin	
			select*from tbUser where userID = ISNULL(@userID,userID)
		end
	else if @action = 'U'
		begin
			update tbUser set
				userEmail = ISNULL(@userEmail,userEmail),
				userPass = ISNULL(@userPass,userPass),
				securityLevel = ISNULL(@securityLevel,securityLevel)
			where userID = @userID
		end
	else if @action = 'D'
		begin
			if exists(select*from tbCustomer where userID = @userID)
				begin
					delete from tbCustomer where userID = @userID
						 if exists(select*from tbCart where userID = @userID)
							begin
								delete from tbCart where userID = @userID
									if exists(select*from tbOrder where userID = @userID)
										begin
											delete from tbOrder where userID = @userID
										end										
							end
				end
		delete from tbUser where userID = @userID

		end
	else if @action = 'F'
				if exists(select*from tbUser where userEmail = @userEmail)
				begin
					select 'invalid' as error
				end
				else
				begin
					select 'good' as error
				end
	else if @action = 'S'
		begin
			if exists(select*from tbUser where userEmail = @userEmail and userPass = @userPass)
				begin
					select * from tbUser inner join tbCustomer on tbUser.userID = tbCustomer.userID where userEmail = @userEmail and userPass = @userPass
				end
			else
				begin
					select 'invalid' as securityLevel
				end
		end
	else if @action = 'P'
		begin
			if exists(select *from tbUser where userEmail = @userEmail)
				begin
					select*from tbUser where userEmail = @userEmail
				end
			else
				begin
					select 'invalid' as userEmail
				end
		end
	else if @action = 'L'
		begin
			if exists(select*from tbUser where userEmail = @userEmail and userPass = @userPass)
				begin
					update tbUser set
					userPass = @newPass
					where userEmail= @userEmail
				end
			else
				begin
					select 'invalid' as userPass
				end
		end	
	else if @action = 'z'
		begin
			select *from tbUser where securityLevel = @securityLevel
		end
end
go
--exec spUser @action = 'z', @securityLevel = 'Admin'
 --== User Proc Over ==--


--== PROCs for table Customer ==--
create proc spCustomer
(
 @userID int = null,
 @firstName varchar(30)= null,
 @lastName varchar(30)= null,
 @phone varchar(30)= null,
 @address varchar(30)= null,
 @action varchar(1)
)
as begin
	if @action = 'C'
		begin
		
			insert into tbCustomer(userID,firstName,lastName,phone,address) values
								  (@userID,@firstName,@lastName,@phone,@address)
		end
	else if @action = 'R'
		begin
			select*from tbCustomer inner join tbUser on tbCustomer.userID = tbUser.userID where tbUser.userID = @userID
		end
	else if @action = 'U'
		begin
			update tbCustomer set
				firstName = ISNULL(@firstName,firstName),
				lastName = ISNULL(@lastName,lastName),
				phone = ISNULL(@phone,phone),
				address = ISNULL(@address,address)
			where userID = @userID
		end
	else if @action = 'D'
		begin
			delete from tbCustomer where userID = @userID
		end
end
--== Customer PROCs End ==--


--== PROCs for table Items ==--
go
create proc spItem
(
	@itemID int = null,
	@itemName varchar(50) = null,
	@itemDescription  varchar(300) = null,
	@itemPrice decimal(16,2) = null,
	@itemGenre varchar(100) = null,
	@itemImg varchar(300) = null,
	@itemStock int = null,
	@action varchar(1) 
)
as begin
	if @action = 'C'
		begin
			insert into tbItems (itemName,itemDescription,itemPrice,itemGenre,itemImg, itemStock) values
								(@itemName,@itemDescription,@itemPrice,@itemGenre,@itemImg,@itemStock)
		end
	else if @action = 'R'
		begin
			select*from tbItems where itemID = isnull(@itemID,itemID)
		end
	else if @action = 'U'
		begin
			update tbItems set
				itemName = ISNULL(@itemName,itemName),
				itemDescription = ISNULL(@itemDescription,itemDescription),
				itemPrice = ISNULL(@itemPrice,itemPrice),
				itemGenre = isnull(@itemGenre,itemGenre),
				itemImg = isnull(@itemImg,itemImg),
				itemStock = ISNULL(@itemStock,itemStock)
			where itemID = @itemID
		end
	else if @action = 'D'
		begin
			delete from tbItems where itemID = @itemID
		end
	else if @action = 'G'
		begin
			select*from tbItems where itemGenre like '%'+@itemGenre+'%'
		end
end
--== Item Procs Over ==--

--== PROCS FOR CART ==-- 
go
create proc spCart
(
	@cartID int = null,
	@userID int = null,
	@itemID int = null,
	@quantity int = null,
	@action varchar(1)
)
as begin
	if @action = 'C'
		begin
			insert into tbCart (userID,ItemId,quantity) values
							(@userID,@itemID,@quantity)
		end
	else if @action = 'R'
		begin
			select*from tbCart inner join tbItems on tbCart.itemID = tbItems.itemID where userID = @userID
		end
	else if @action = 'U'
		begin
			update tbCart set
			quantity = ISNULL(@quantity,quantity)
			where userID = @userID and cartID = @cartID
		end
	else if @action = 'd'
		begin
			delete from tbCart where cartID = @cartID
		end
	else if @action = 't'
		begin
			select sum(itemprice * quantity) as totalAmount from tbCart inner join tbItems on tbCart.itemID = tbItems.itemID where userID = @userID
		end
	else if @action = 'g'
		begin
			select sum(itemprice * quantity) as totalAmount from tbCart inner join tbItems on tbCart.itemID = tbItems.itemID where userID is null
		end
	else if @action = 'm'
		begin
			update tbCart set
			quantity = ISNULL(@quantity,quantity)
			where userID is null and cartID = @cartID
		end

end
--== ORDER tbOrder Procs ==--
go
create proc spOrder
(
	@orderID int = null,
	@userID int = null,
	@orderDate date = null,
	@total decimal(16,2) = null,
	@action varchar(1) = null
)
as begin
	if @action = 'c'
		begin
			insert into tbOrder(userID,orderDate,total) values (@userID,@orderDate,@total)
		select @@IDENTITY as orderID
		end
	else if @action = 'r'
		begin
			select*from tbOrder
		end
	else if @action = 'u'
		begin
			update tbOrder set
				userID = ISNULL(@userID,userID),
				orderDate = ISNULL(@orderDate,orderDate),
				total = isnull(@total,total)
			where orderID = @orderID
		end
	else if @action = 'd'
		 begin
			delete from tbOrder where orderID = @orderID
		 end
	else if @action = 'i' -- Identity
		begin
			select @@IDENTITY as orderID
		end
			else if @action = 'a'
		begin
			select tbOrder.orderID,tbOrderItems.orderItemID,tbUser.userID,orderDate,tbItems.itemID,itemName,itemPrice,quantity,itemStock,userEmail,firstName,lastName,address,phone
			from tbOrder inner join tbOrderItems on tbOrder.orderID = tbOrderItems.orderID
								inner join tbItems on tbOrderItems.itemID = tbItems.itemID
								inner join tbUser on tbOrder.userID = tbUser.userID
								inner join tbCustomer on tbUser.userID = tbCustomer.userID
								where tbOrder.orderID =ISNULL(@orderID,tbOrder.orderID)
		end
	else if @action = 'b'
		begin
			select tbOrder.orderID,firstName + ' ' + lastName as Name,orderItemID,orderDate,quantity,total,itemName,itemImg from tbOrder inner join tbOrderItems on tbOrder.orderID = tbOrderItems.orderID
								inner join tbItems on tbItems.itemID = tbOrderItems.itemID 
								inner join tbCustomer on tbOrder.userID = tbCustomer.userID where tbOrder.userID = ISNULL(@userID,tbOrder.userID)
		end
end
--exec spOrder @action ='b',@userID = 1

go
create proc spOrderItems
(
	@orderItemID int = null,
	@orderID int = null,
	@itemID int = null,
	@quantity int =null,
	@itemStock int = null,
	@action varchar(1) = null
)
as begin
	if @action = 'c'
		begin
			
			insert into tbOrderItems(orderID,itemID,quantity) values
									(@orderID,@itemID,@quantity)
			update tbItems set
			itemStock = itemStock - @quantity
			where itemID = @itemID 

			delete from tbCart where cartID > 0
		end
	else if @action = 'r'
		begin
			select*from tbOrderItems where orderID = @orderID
		end
	else if @action = 'u'
		begin
			update tbOrderItems set
			itemID = isnull(@itemID,itemID),
			quantity = ISNULL(@quantity,quantity)
			where orderItemID = @orderItemID
		end
	else if @action = 'd'
		begin
		 delete from tbOrderItems where orderItemID = @orderItemID
		 end
	else if @action = 'p'
		begin -- might change to UserID or OrderID idk yet
			select sum(itemPrice) from tbOrderItems inner join tbItems on tbOrderItems.itemID = tbItems.itemID where orderID = @orderID
		end
	else if @action = 'y'
		begin
						select tbOrder.orderID,tbOrderItems.orderItemID,tbUser.userID,tbItems.itemID,itemName,itemPrice,quantity,itemStock,userEmail,firstName,lastName,address,phone
			from tbOrder inner join tbOrderItems on tbOrder.orderID = tbOrderItems.orderID
								inner join tbItems on tbOrderItems.itemID = tbItems.itemID
								inner join tbUser on tbOrder.userID = tbUser.userID
								inner join tbCustomer on tbUser.userID = tbCustomer.userID
								where orderItemID = @orderItemID
		end


end
go
create proc spUpdateOrder
(
	@orderID int =null,
	@orderItemID int=null,
	@userID int=null,
	@itemID int=null,
	@itemName varchar(30)=null,
	@itemPrice decimal(16,2)=null,
	@quantity int=null,
	@userEmail varchar(40)=null,
	@firstName varchar(40)=null,
	@lastName varchar(40)=null,
	@phone varchar(40)=null,
	@address varchar(40)=null
)
as begin
	update tbOrder set
		userID = ISNULL(@userID,userID)
		where orderID = @orderID
	update tbOrderItems set
		orderID = ISNULL(@orderID,orderID),
		itemID = ISNULL(@itemID,itemID),
		quantity = isnull(@quantity,quantity)
		where orderItemID = @orderItemID
end
go

create proc spSearchBar
(
	@search varchar(100)
)
as begin
	select*from tbItems where itemName like '%'+ @search +'%' or itemGenre like '%' + @search + '%'
end	

--exec spSearchBar @search = 'hat'


--==CART ORDDER TEST == ---
--exec spOrder @action = 'c',@userID='1'
--select *from tbOrder
--exec spOrderItems @action='c',@orderID=1,@itemID=2,@quantity=1
--exec spOrderItems @action='c',@orderID=1,@itemID=3,@quantity=1
--select orderItemID, orderID,tbItems.itemID, itemName,itemPrice,itemImg,SUM(itemPrice) from tbOrderItems inner join tbItems on tbItems.itemID = tbOrderItems.itemID where orderID= 1 group by orderItemID, orderID,tbItems.itemID, itemName,itemPrice,itemImg
--select*from tbItems where itemID = 23
--select Sum(itemPrice) from tbOrderItems inner join tbItems on tbItems.itemID = tbOrderItems.itemID
--select*from tbCart
--select sum(itemPrice) from tbOrderItems inner join tbItems on tbOrderItems.itemID = tbItems.itemID where orderID =1
--select*from tbOrder inner join tbOrderItems on tbOrder.orderID = tbOrderItems.orderID where userID = 1
go 
create proc spSortItemAdmin
(
	@item varchar(30),
	@direction varchar(30)
)
as begin
	select*from tbItems order by
		case when @direction = 'Ascending' and @item ='itemID' then itemID end asc,
		case when @direction = 'Descending' and @item = 'itemID' then itemID end desc,
		case when @direction = 'Ascending' and @item ='itemName' then itemName end asc,
		case when @direction = 'Descending' and @item = 'itemName' then itemName end desc,
		case when @direction = 'Ascending' and @item ='itemDescription' then itemDescription end asc,
		case when @direction = 'Descending' and @item = 'itemDescription' then itemDescription end desc,
		case when @direction = 'Ascending' and @item ='itemPrice' then itemPrice end asc,
		case when @direction = 'Descending' and @item = 'itemPrice' then itemPrice end desc,
		case when @direction = 'Ascending' and @item ='itemGenre' then itemGenre end asc,
		case when @direction = 'Descending' and @item = 'itemGenre' then itemGenre end desc,
		case when @direction = 'Ascending' and @item ='itemImg' then itemImg end asc,
		case when @direction = 'Descending' and @item = 'itemImg' then itemImg end desc,
		case when @direction = 'Ascending' and @item ='itemStock' then itemStock end asc,
		case when @direction = 'Descending' and @item = 'itemStock' then itemStock end desc
end

--exec spSortItemAdmin @item = 'itemName',@direction='Descending'