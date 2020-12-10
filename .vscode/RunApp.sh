#! /bin/sh

path='C:\Users\53433\source\e-commerce'; # ADD YOUR PROJECT PATH HERE

cd ${path}

msbuild.exe

sleep 0.5

bin/Debug/ECommerce_Application.exe