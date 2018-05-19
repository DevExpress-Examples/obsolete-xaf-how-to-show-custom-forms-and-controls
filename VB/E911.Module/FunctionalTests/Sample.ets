;#DropDB E911EasyTest

#Application E911.Win
#Application E911.Web

*Action Navigation(User)

*ProcessRecord
 User Name = [DomainUserName]

*OptionalAction Edit
 
*FillForm
 User Name = Test User
 
*Action Cancel

*OptionalAction Yes

*CheckFieldValues
 User Name = [DomainUserName]
