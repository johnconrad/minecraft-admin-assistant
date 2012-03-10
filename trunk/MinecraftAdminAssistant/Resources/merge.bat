@echo off

md merged
IF EXIST merged\MinecraftAdminAssistant.exe del merged\MinecraftAdminAssistant.exe
ilmerge /targetplatform:v4 /out:merged\MinecraftAdminAssistant.exe MinecraftAdminAssistant.exe JSONAPI.dll

