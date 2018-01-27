    using UnityEngine;

public class Wall : MonoBehaviour
{
    public AudioClip ChopSound1;
    public AudioClip ChopSound2;
    public Sprite DmgSprite;
    public int Hp = 4;

    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DamageWall(int loss)
    {
        SoundManager.Instance.RandomizeSfx(ChopSound1, ChopSound2);
        _spriteRenderer.sprite = DmgSprite;
        Hp -= loss;
        if (Hp <= 0)
            gameObject.SetActive(false);
    }
}