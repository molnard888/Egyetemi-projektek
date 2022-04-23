#include "admin.h"
#include <iostream>
#include <string.h>

using namespace std;

bool admin::getIsAdmin() const
{
    return isAdmin;
}

void admin::setIsAdmin(bool value)
{
    isAdmin = value;
}

admin::admin()
{
}

admin::~admin()
{

}
