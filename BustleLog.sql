create table dbo.LogRecord(
	[ID] [int] IDENTITY(1,1) NOT NULL primary key, 
	[MachineName] [nvarchar](200) NULL,
	[SiteName] [nvarchar](200) NOT NULL,
	[Logged] [datetime] NOT NULL,
	[Level] [varchar](5) NOT NULL,
	[UserName] [nvarchar](200) NULL,
	[Message] [nvarchar](max) NOT NULL,
	[Logger] [nvarchar](300) NULL,
	[Properties] [nvarchar](max) NULL,
	[ServerName] [nvarchar](200) NULL,
	[Port] [nvarchar](100) NULL,
	[Url] [nvarchar](2000) NULL,
	[Https] [bit] NULL,
	[ServerAddress] [nvarchar](100) NULL,
	[RemoteAddress] [nvarchar](100) NULL,
	[Callsite] [nvarchar](300) NULL,
	[Exception] [nvarchar](max) NULL)
go

create procedure dbo.AddLogEntry(
  @machineName nvarchar(200),
  @siteName nvarchar(200),
  @logged datetime,
  @level varchar(5),
  @userName nvarchar(200),
  @message nvarchar(max),
  @logger nvarchar(300),
  @properties nvarchar(max),
  @serverName nvarchar(200),
  @port nvarchar(100),
  @url nvarchar(2000),
  @https bit,
  @serverAddress nvarchar(100),
  @remoteAddress nvarchar(100),
  @callSite nvarchar(300),
  @exception nvarchar(max)) 
as
begin
  insert into dbo.LogRecord (
    [MachineName],
    [SiteName],
    [Logged],
    [Level],
    [UserName],
    [Message],
    [Logger],
    [Properties],
    [ServerName],
    [Port],
    [Url],
    [Https],
    [ServerAddress],
    [RemoteAddress],
    [CallSite],
    [Exception]
  ) values (
    @machineName,
    @siteName,
    @logged,
    @level,
    @userName,
    @message,
    @logger,
    @properties,
    @serverName,
    @port,
    @url,
    @https,
    @serverAddress,
    @remoteAddress,
    @callSite,
    @exception
  );
end
go