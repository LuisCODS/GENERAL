window.onload = function()
{
    var canvas = document.createElement('canvas');
    canvas.width = 900;
    canvas.height = 600;
    canvas.style.border = "1px solid";
    document.boody.appendChild(canvas);   
    
    var cxt = canvas.getContext('2d');
    cxt.fillStyle = "#ff0000";
    cxt.fillRect(30, 30, 100, 50);
    
}