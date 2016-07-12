Create table appUser
(
	userID varchar(500) not null,
	firstName varchar(20) not null,
	lastName varchar(20) not null,

	constraint pk_user_id primary key (userID)
);

Create table searchQuery
(
	searchID int identity not null,
	basicKeywords varchar(200) null,
	exactMatchKeywords varchar(200) null,
	notKeywords varchar(200) null,
	exactPrice float null,
	numberRangeLow float null,
	numberRangeHigh float null,
	numberRangeUnit varchar(10) null,
	region varchar(50) null,
	siteSearch varchar(50) null,
	domainSearch varchar(50) null,
	searchFrequency int not null,
	frequencyUnit varchar not null,

	constraint pk_search_id primary key (searchID),
	constraint chk_exactPrice check (exactPrice>0),
	constraint chk_numberRangeLow_numberRangeHigh check((numberRangeLow is null 
														AND numberRangeHigh is null) OR (numberRangeLow is not null 
														AND numberRangeHigh is not null 
														AND numberRangeLow<numberRangeHigh)),
	constraint chk_domainSearch check (domainSearch like '.%'),
	constraint chk_siteSearch check (siteSearch like '%.%'),
	constraint chk_searchFrequency check (searchFrequency >0),
	constraint chk_frequencyUnit check (frequencyUnit in ('Seconds','Minutes','Hours','Days','Months'))
);

Create table appUser_searchQuery
(
	userID varchar(500) not null,
	searchID int not null,

	constraint pk_userID_searchID primary key (userID,SearchID),
	constraint fk_appUser_searchQuery_userID foreign key (userID) references appUser (userID),
	constraint fk_appUser_searchQuery_searchID foreign key (searchID) references searchQuery (searchID)
);