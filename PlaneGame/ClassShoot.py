class bullet:

    def __init__(self, xy, xyPos, img):
        self.xDirection, self.yDirection = xy
        self.xPos, self.yPos = xyPos
        self.img = img

    def getXY(self):
        return self.xDirection, self.yDirection

    def setXY(self, xyDirection):
        self.xDirection, self.yDirection = xyDirection

    def getPoss(self):
        return self.xPos, self.yPos

    def setPoss(self, xyPos):
        self.xPos, self.yPos = xyPos

    def getImg(self):
        return self.img

    def getAngle(self):
        # Up and Right
        if (self.xDirection == 1) and (self.yDirection == -1):
            return 45

        # Right
        elif (self.xDirection == 1) and (self.yDirection == 0):
            return 90

        # Down and Right
        elif (self.xDirection == 1) and (self.yDirection == 1):
            return 135

        # Down
        elif (self.xDirection == 0) and (self.yDirection == 1):
            return 180

        # Down and Left
        elif (self.xDirection == -1) and (self.yDirection == 1):
            return 225

        # Left
        elif (self.xDirection == -1) and (self.yDirection == 0):
            return 270

        # Up and Left
        elif (self.xDirection == -1) and (self.yDirection == -1):
            return 315

        # Up
        else:
            return 0

    def getHitBox(self):
        if (self.xDirection == -1 and self.yDirection == 0) or (self.xDirection == 1 and self.yDirection == 0):
            return (self.xPos + 35, self.yPos + 19, 30, 62)
        return (self.xPos + 19, self.yPos + 35, 62, 30)
