#pragma strict

function Update()
{
    transform.Rotate(0, 20 * Time.deltaTime, 0);
}
