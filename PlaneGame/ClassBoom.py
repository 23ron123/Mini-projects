class boom:

    def __init__(self, xyPos, img):
        self.xPos, self.yPos = xyPos
        self.img = img
        self.index = 100

    def getPoss(self):
        return self.xPos, self.yPos

    def setPoss(self, xyPos):
        self.xPos, self.yPos = xyPos

    def getIndex(self):
        return self.index

    def getXY(self):
        pass

    def update(self):
        self.index -= 1


    def getImg(self):
        return self.img
