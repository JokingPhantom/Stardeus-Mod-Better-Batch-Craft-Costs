A quick mod I threw together to adjust power costs for crafting in v0.11 alpha. You can use this as a starting point for your own mod, though there may be changes later as v0.11 gets finished by the developer.

Uses Harmony to adjust the code.

What this code already does for you:
1. Starts from the v0.10 mod template
2. Adjust `.vscode\mod.csproj` to compile for `net472` instead of `net470`
3. Inside the `Code` folder, write a class that starts the Harmony patching process. This example is in `BatchCraftPatcher`

Quick guide to modding with Harmony for v0.11:
1. Adjust `.vscode\launch.json` and `.vscode\mod.csproj` to target your installation of Stardeus
2. Decompile the game with dnSpy or DotPeek. *
3. Search the code for what you want to change - for example, `Game.Utils.Equations` is where some interesting formulas are, `Game.Systems.Sleep` is sleep related code, `Game.UI` is where tooltips live, etc.
4. Make your own version of the method you want to change.
5. Format it according to Harmony Lib documentation. For example, to override a method completely, make it a Prefix method, return signature of a boolean, set the final result in the variable `__result`, and return false to prevent the original method from working. Harmony Lib documentation lists a number of different ways to change behavior, this is only the simplist type.

Harmony Lib Documentation: https://harmony.pardeike.net/articles/intro.html
dnSpy: https://github.com/dnSpy/dnSpy
dotPeek: https://www.jetbrains.com/decompiler/

*These are .NET decompilers. There are others, but these are good ones to start with. Each decompiler may give slightly different results, which can be better for hard to decompile games. Stardeus is easy to decompile, so there should be no need to use multiple decompilers.
