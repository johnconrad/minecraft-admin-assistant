@echo off

md merged
IF EXIST merged\MinecraftAssistant.exe del merged\MinecraftAssistant.exe
ilmerge /targetplatform:v4 /out:merged\MinecraftAssistant.exe MinecraftAssistant.exe JSONAPI.dll

