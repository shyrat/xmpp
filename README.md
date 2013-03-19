# Ubiety XMPP Library #

Ubiety is an extensible XMPP library written in C# to be easy and powerful.

## Fork Notes ##

* First, thanks to Dieter Lunn for his great ubiety xmpp library
* This fork is designed to work with Windows 8 and .netCore
* It is based on a event driven concept and multi-instancable
* The keepalive part is not tested at the time of writing
* Note that Windows 8 rejects connections with invalid SSL certificates

## Basics ##

For basic usage you only need to create an instance of the Client interface

	using XMPP;
	XMPP.Client Client = new XMPP.Client();

### Events ###

	OnError				// An error occured 
	OnLogMessage			// Debugging output ( most messages only work in debug configuration)
	
	OnDisconnected		// The client is disconnected
	OnConnected			// The client is connected
	
	OnResourceBound		// The client received a resource ID from the server
	OnReady				// The client is now logged in and ready 
	
	OnReceive				// The client received a tag with user relevant data
	OnNewTag				// The client received a tag ( connection relevant and user relevant )
  
### Properties ###

	Version				// Which version of the client this is
	Settings			// Change the values in this object to define how the client should behave
	Connected			// Boolean value to determine if the client is connected
	Socket				// You can overwrite the internally created socket with your own
	ProcessComplete		// ManualResetEvent to wait for the client to process all received data

### Actions ### 

   Connect()			// Connect with the already supplied settings
   Disconnect()			// Disconnect
   Send(Tag tag)		// Send a tag
   Send(TagEventArgs e)	// Send a tag as args object

## Settings ##

	Id					// The client Jabber ID ( can be supplied as string )
	Password			// The password to connect
	Hostname			// The host to connect
	Port				// The port to connect
	
	AuthenticationTypes // Which authentication methods will be supported (OAUTH2 not yet implemented)
	SSL					// Connect and Upgrade to SSL if available
	OldSSL				// Connect directly with SSL ( SSL has to be enabled too )
	
	UseKeepAlive		// Enable keepalives ( not tested )
	KeepAliveTime		// Keepalive interval

## Example ##

	XMPP.Client Client = new XMPP.Client();

	Client.Settings.Hostname = "example.com";
	Client.Settings.SSL = false;
	Client.Settings.OldSSL = false;
	Client.Settings.Port = 5222;
	Client.Settings.Id = "user@example.com";
	Client.Settings.Password = "userpassword";
	
	Client.Connect();


