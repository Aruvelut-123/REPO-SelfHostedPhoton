# Self Hosted Photon

With this mod you can easily join to a self-hosted version of Photon via an IP address or a hostname.

## DISCLAIMER

This mod is not yet finished, so you may experience some issues. If you do do not hesitate to create a new issue on the project GitHub.

## Setup

### For Server Hosts

To use this mod you will need a Photon Server first of all. There is a nice [GitHub project](https://github.com/GillesZunino/Dockerized-Photon) that allows you to run your own Photon server via [Docker](https://www.docker.com/).

After you have set up the server you need to share the server address and port with your clients.

From this point you can just follow the client setup.

### For Clients

First of all will need to enable the mod and set the server address and port in the configs, after you can just join a game (the lobby host and the server host does not have to be the same person).

## Config

Example config

```cfg
## Settings file was created by plugin Self_Hosted_Photon v0.0.0
## Plugin GUID: Self_Hosted_Photon

[General]

## Enable or disable the plugin.
# Setting type: Boolean
# Default value: true
Enabled = true

[Server]

## The IP address or hostname of the Photon server.
# Setting type: String
# Default value: 127.0.0.1
Address = 127.0.0.1

## The port number of the Photon server.
# Setting type: String
# Default value: 5055
Port = 5055
```

To save yourself some trouble you can use the [REPOConfig](https://thunderstore.io/c/repo/p/nickklmao/REPOConfig/) mod that allows you to change your settings in-game.

## Credit

Credit to [REPOLib](https://thunderstore.io/c/repo/p/Zehs/REPOLib/) for the GitHub CI/CD pipeline.
