#! /bin/sh

path='D:\Projects\dotNetprojects\e-commerce'; # ADD YOUR PROJECT PATH HERE

cd ${path}

msbuild.exe

sleep 0.5

bin/Debug/ECommerce_Application.exe