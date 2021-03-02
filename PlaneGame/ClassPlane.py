import random

class CrazyPlane:

    def __init__(self, x, y, img, strName, status):
        self.x = 0
        self.y = 0
        self.xPos = x
        self.yPos = y
        self.img = img
        self.strName = strName
        self.status = status

    def updatePoss(self):
        self.x = random.randint(-1, 1)
        self.y = random.randint(-1, 1)

    def setXY(self, x, y):
        self.x = x
        self.y = y

    def getPoss(self):
        return self.xPos, self.yPos

    def getRott(self):
        return self.x, self.y

    def getCenter(self):
        return self.xPos + 50, self.yPos + 50

    def getImg(self):
        return self.img

    def setImg(self, img):
        self.img = img

    def setPoss(self, xyPoss):
        self.xPos, self.yPos = xyPoss

    def getStrName(self):
        return self.strName

    def getStatus(self):
        return self.status

    def setStatus(self, status):
        self.status = status

    def getHitBox(self):
        return ((self.xPos, self.yPos + 35, 100, 30), (self.xPos + 35, self.yPos, 30, 100))

    def getAngle(self):
        # Up and Right
        if (self.x == 1) and (self.y == -1):
            return 45

        # Right
        elif (self.x == 1) and (self.y == 0):
            return 90

        # Down and Right
        elif (self.x == 1) and (self.y == 1):
            return 135

        # Down
        elif (self.x == 0) and (self.y == 1):
            return 180

        # Down and Left
        elif (self.x == -1) and (self.y == 1):
            return 225

        # Left
        elif (self.x == -1) and (self.y == 0):
            return 270

        # Up and Left
        elif (self.x == -1) and (self.y == -1):
            return 315

        # Up
        else:
            return 0

    def printInfo(self, x):
        strStatus = "Ofline"
        if (self.status):
            strStatus = "Online"

        print("---------- ", x, " ----------")
        print("Name: ", self.strName, ", Status: ", strStatus)
        print("Direction: ( x = ", self.x, ", y = ", self.y, " )")
        print("Position: ( x = ", self.xPos, ", y = ", self.yPos, " )")