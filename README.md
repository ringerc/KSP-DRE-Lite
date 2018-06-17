# DRE-Lite

Make heat shields capable of failing, and make ablator depletion matter. Simply.

See [user README](ImprovedAblator/GameData/ImprovedAblator/README.md) for details.

# Compile

To compile, make sure you have MonoDevelop installed then

    xbuild /p:Configuration=Release

or open the project in `MonoDevelop` and "rebuild all".

Then copy `ImprovedAblator/bin/Release/GameData/ImprovedAblator` to your KSP's GameData.

Start the game. Watch the firey death.

# Pre-built

No pre-built packages yet.

I'm looking at how to automate with Travis CI but there are obvious legal
concerns with the KSP assemblies. GitHub doesn't offer user uploads.
