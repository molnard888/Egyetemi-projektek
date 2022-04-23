#ifndef ADMIN_H
#define ADMIN_H
#include "dolgozo.h"

class admin: public Dolgozo
{
    bool isAdmin=true;
public:
    admin();
    ~admin();
    bool getIsAdmin() const;
    void setIsAdmin(bool value);
};

#endif // ADMIN_H
