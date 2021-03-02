#ron miretsky
import ClassPlane
import ClassShoot
import ClassBoom
import pygame

#מחזיר לאיזה פוזיציה צריך לקדם את המטוס
def addVelocityPlane(i):
    x, y = i.getRott()
    xPos, yPos = i.getPoss()

    if (x == -1) and (y == 0):
        xPos -= 0.2
        if (xPos < -50):
            xPos = 950

        return (xPos, yPos)

    elif (x == 0) and (y == 1):
        yPos += 0.2
        if (yPos > 950):
            yPos = -50

        return (xPos, yPos)

    elif (x == 1) and (y == 0):
        xPos += 0.2
        if (xPos > 950):
            xPos = -50

        return (xPos, yPos)

    else:
        yPos -= 0.2
        if (yPos < -50):
            yPos = 950

        return (xPos, yPos)

#מחזיר לאיזה פוזיציה צריך לקדם את בן
def addVelocityPlaneBen(i):
    x, y = i.getRott()
    xPos, yPos = i.getPoss()

    if (x == -1) and (y == 0):
        xPos -= 0.3
        if (xPos < -50):
            xPos = 950

        return (xPos, yPos)

    elif (x == 0) and (y == 1):
        yPos += 0.3
        if (yPos > 950):
            yPos = -50

        return (xPos, yPos)

    elif (x == 1) and (y == 0):
        xPos += 0.3
        if (xPos > 950):
            xPos = -50

        return (xPos, yPos)

    else:
        yPos -= 0.3
        if (yPos < -50):
            yPos = 950

        return (xPos, yPos)

#בדיקה אם שני מטוסים מתנגשים
def checkPlaneHitPlane(plane1, plane2):

    if (plane2.getPoss()[1] + 30 < plane1.getHitBox()[0][1] + plane1.getHitBox()[0][3] and plane2.getPoss()[1] + 70 > plane1.getHitBox()[0][1]):
        if (plane2.getPoss()[0] + 100 > plane1.getHitBox()[0][0] and plane2.getPoss()[0] < plane1.getHitBox()[0][0] + plane1.getHitBox()[0][2]):
            return True

    if (plane2.getPoss()[1] < plane1.getHitBox()[1][1] + plane1.getHitBox()[1][3] and plane2.getPoss()[1] + 100 > plane1.getHitBox()[1][1]):
        if (plane2.getPoss()[0] + 70 > plane1.getHitBox()[1][0] and plane2.getPoss()[0] < plane1.getHitBox()[1][0] - 25 + plane1.getHitBox()[1][2]):
            return True

#מראה את כל המטוסים
def showPlanes(win, planes):
    for tempPlane in planes:
        if (tempPlane.getStatus()):
            tempImg = pygame.transform.rotate(tempPlane.getImg(), -tempPlane.getAngle())
            win.blit(tempImg, tempPlane.getPoss())

#מראה את כל ההיטבוקס
def showHitBox(win, planes, bullets):
    for tempPlane in planes:
        if (tempPlane.getStatus()):
            pygame.draw.rect(win, (255, 0, 0), tempPlane.getHitBox()[0], 2)
            pygame.draw.rect(win, (255, 0, 0), tempPlane.getHitBox()[1], 2)

    for tempBullet in bullets:
        pygame.draw.rect(win, (255, 0, 0), tempBullet.getHitBox(), 2)

#מראה את האמצע של המטוסים
def showPlanesCenter(win, planes):
    for tempPlane in planes:
        if (tempPlane.getStatus()):
            pygame.draw.circle(win, (0, 255, 0), tempPlane.getCenter(), 5)

#משנה כייון לכל הבוטים
def rotateAllBotPlanes(planes):
    distanceX = 0
    distanceY = 0

    x, y = 0, 0
    for tempPlane in planes:
        if (tempPlane.getStatus()):
            if(tempPlane.getStrName() != "Ben Plane"):
                distanceX = tempPlane.getPoss()[0] - planes[0].getPoss()[0]
                distanceY = tempPlane.getPoss()[1] - planes[0].getPoss()[1]

                if(abs(distanceX) > abs(distanceY)):
                    if(distanceX < 0):
                        if(abs(distanceX > 500)):
                            x = -1

                        else:
                            x = 1

                    else:
                        if (abs(distanceX > 500)):
                            x = 1

                        else:
                            x = -1

                else:
                    if (distanceY < 0):
                        if (abs(distanceY > 500)):
                            y = -1

                        else:
                            y = 1

                    else:
                        if (abs(distanceY > 500)):
                            y = 1

                        else:
                            y = -1

                tempPlane.setXY(x, y)

#מקדם את כל המטוסים
def promoteAllBotPlanes(planes):
    for tempPlane in planes:
        if (tempPlane.getStatus() and tempPlane.getStrName() != "Ben Plane"):
            tempPlane.setPoss(addVelocityPlane(tempPlane))

#בודק אם הכדור מצא במגרש
def checkIfBulletInside(bullet):
    xPos, yPos = bullet.getPoss()

    if (xPos < -50):
        return False

    if (yPos > 950):
        return False

    if (xPos > 950):
        return False

    if (yPos < -50):
        return False
    return True

#לקדם את הכדור
def addVelocityBullet(bullet):
    x, y = bullet.getXY()
    xPos, yPos = bullet.getPoss()

    if (x == -1) and (y == 0):
        xPos -= 0.35
        return (xPos, yPos)

    elif (x == 0) and (y == 1):
        yPos += 0.35
        return (xPos, yPos)

    elif (x == 1) and (y == 0):
        xPos += 0.35
        return (xPos, yPos)

    else:
        yPos -= 0.35
        return (xPos, yPos)

#להראות את הכדורים%
def showBullets(win, bullets):
    for bullet in bullets:
        tempImg = pygame.transform.rotate(bullet.getImg(), -bullet.getAngle())
        win.blit(tempImg, bullet.getPoss())

#פגיעה של כדור במטוס
def checkBulletHitPlane(bullets, plane):
    for bullet in bullets:
        if (bullet.getPoss()[1] + 35 < plane.getHitBox()[0][1] + plane.getHitBox()[0][3] and bullet.getPoss()[1] + 65 > plane.getHitBox()[0][1]):
            if (bullet.getPoss()[0] + 50 > plane.getHitBox()[0][0] and bullet.getPoss()[0] + 50 < plane.getHitBox()[0][0] + plane.getHitBox()[0][2]):
                bullets.pop(bullets.index(bullet))
                return True

        if (bullet.getPoss()[1] + 20 < plane.getHitBox()[1][1] + plane.getHitBox()[1][3] and bullet.getPoss()[1] + 80 > plane.getHitBox()[1][1]):
            if (bullet.getPoss()[0] + 90 > plane.getHitBox()[1][0] and bullet.getPoss()[0] < plane.getHitBox()[1][0] + plane.getHitBox()[1][2]):
                bullets.pop(bullets.index(bullet))
                return True


def main():
    pygame.init()
    pygame.font.init()
    win = pygame.display.set_mode((1000, 1000))
    pygame.display.set_caption("Plane Game")

    imgBenPlane = pygame.image.load("plane\BenPlane.png")
    imgPlaneBlue = pygame.image.load("plane\BluePlane.png")

    imgBullet = pygame.image.load("plane\FirePlane.png")

    planeBen = ClassPlane.CrazyPlane(400, 400, imgBenPlane, "Ben Plane", True)
    planeBlue = ClassPlane.CrazyPlane(600, 600, imgPlaneBlue, "Blue plane", True)

    imgSky = pygame.image.load("plane\skyRibooa.png")
    imgBoom = pygame.image.load(r"plane\boom.png")
    imgBoomMini = pygame.image.load(r"plane\Miniboom.png")

    booms = []
    bullets = []
    planes = [planeBen, planeBlue]

    hitBoxLoop = 0
    ShowHitBox = False

    centerLoop = 0
    ShowHitCenter = False

    shootLoop = 0
    counterRound = 0

    # מסך הפתיחה
    for k in range(3):
        win.blit(imgSky, (0, 0))
        myfont = pygame.font.SysFont('didot.ttc', 200)
        name = myfont.render(str(3 - k), True, (255, 55, 0))
        win.blit(name, (460, 440))
        pygame.display.flip()
        pygame.time.delay(1000)

    win.blit(imgSky, (0, 0))
    myfont = pygame.font.SysFont('didot.ttc', 300)
    name = myfont.render("Start!", True, (255, 55, 0))
    win.blit(name, (230, 400))
    pygame.display.flip()
    pygame.time.delay(1000)

    #המשחק
    run = True
    boolQuit = False
    while(run and planeBen.getStatus()):
        if (checkPlaneHitPlane(planeBlue, planeBen)):
            planeBen.setStatus(False)
            planeBlue.setStatus(False)
            boolQuit = True

        if (checkBulletHitPlane(bullets, planeBlue)):
            tempBoom = ClassBoom.boom(planeBlue.getPoss(), imgBoomMini)
            booms.append(tempBoom)
            planeBlue.setStatus(False)

        if(hitBoxLoop > 0):
            hitBoxLoop += 1
        if(hitBoxLoop  > 100):
            hitBoxLoop= 0

        if (centerLoop > 0):
            centerLoop += 1
        if (centerLoop > 100):
            centerLoop = 0

        if (shootLoop > 0):
            shootLoop += 1
        if (shootLoop > 200):
            shootLoop = 0

        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                run = False

        for bullet in bullets:
            if(checkIfBulletInside(bullet)):
                bullet.setPoss(addVelocityBullet(bullet))

            else:
                bullets.pop(bullets.index(bullet))

        keys = pygame.key.get_pressed()

        if (keys[pygame.K_h] and hitBoxLoop == 0):
            if (ShowHitBox):
                ShowHitBox = False

            else:
                ShowHitBox = True

            hitBoxLoop = 1

        if (keys[pygame.K_c] and centerLoop == 0):
            if (ShowHitCenter):
                ShowHitCenter = False

            else:
                ShowHitCenter = True

            centerLoop = 1

        if (keys[pygame.K_SPACE] and shootLoop == 0):
            if(len(bullets) < 6):
                tempBullet = ClassShoot.bullet(planeBen.getRott(), planeBen.getPoss(), imgBullet)
                bullets.append(tempBullet)
            shootLoop = 1

        elif (keys[pygame.K_w]):
            planeBen.setXY(0, -1)
            planeBen.setPoss(addVelocityPlaneBen(planeBen))

        elif (keys[pygame.K_a]):
            planeBen.setXY(-1, 0)
            planeBen.setPoss(addVelocityPlaneBen(planeBen))

        elif (keys[pygame.K_s]):
            planeBen.setXY(0, 1)
            planeBen.setPoss(addVelocityPlaneBen(planeBen))

        elif (keys[pygame.K_d]):
            planeBen.setXY(1, 0)
            planeBen.setPoss(addVelocityPlaneBen(planeBen))

        if(counterRound%200 == 0):
            rotateAllBotPlanes(planes)
            counterRound = 0

        promoteAllBotPlanes(planes)

        win.blit(imgSky, (0, 0))
        showPlanes(win, planes)
        showBullets(win, bullets)

        if(ShowHitBox):
            showHitBox(win, planes, bullets)

        if(ShowHitCenter):
            showPlanesCenter(win, planes)

        if(planeBen.getStatus() == False):
            win.blit(imgBoom, (planeBlue.getPoss()[0] - 100, planeBlue.getPoss()[1] - 100))

        for boom in booms:
            win.blit(boom.getImg(), (planeBlue.getPoss()[0], planeBlue.getPoss()[1]))
            boom.update()
            if(boom.getIndex() == 0):
                booms.pop(booms.index(boom))

        pygame.display.flip()
        counterRound+=1

    # סוף המשחק
    run = True
    while (run and boolQuit):
        win.blit(imgSky, (0, 0))
        win.blit(imgBoom, (planeBlue.getPoss()[0] - 100, planeBlue.getPoss()[1] - 100))
        pygame.time.delay(1000)

        myfont = pygame.font.SysFont('didot.ttc', 200)
        name = myfont.render("Dead!", True, (255, 55, 0))
        win.blit(name, (310, 440))

        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                run = False
        pygame.display.flip()

    pygame.quit()

if __name__ == '__main__':
    main()

