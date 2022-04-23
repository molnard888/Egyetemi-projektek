TEMPLATE = app
CONFIG += console c++11
CONFIG -= app_bundle
CONFIG -= qt

LIBS += -pthread

SOURCES += \
        adapter2.cpp \
        generator.cpp \
        main.cpp \
        szemely.cpp \
        vizsgalat.cpp

HEADERS += \
    adapter2.h \
    generator.h \
    interfesz1.h \
    interfesz2.h \
    interfesz3.h \
    szemely.h \
    tombolvaso.h \
    vizsgalat.h

DISTFILES += \
    beolvasott-minta.txt \
    kimenet-minta.txt
