public interface IBoss{
    public bool IsBoss();
    public void Spawn(ref BossRoomMan bossRoom);
    public void OnDeath();
}