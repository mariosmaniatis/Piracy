var crosshairTexture : Texture2D;
var position : Rect;
static var OriginalOn = true;
 
function Start()

{
    Screen.lockCursor = true;
    position = Rect((Screen.width - (crosshairTexture.width / 64)) / 2, (Screen.height - 
        (crosshairTexture.height / 64)) /2, crosshairTexture.width / 64, crosshairTexture.height / 64);
}
 
function OnGUI()
{
    if(OriginalOn == true)
    {
        GUI.DrawTexture(position, crosshairTexture);
    }
}

function OnMouseDown () {
    // Lock the cursor
    Screen.lockCursor = true;
}