public class StageStarManager
{
    [System.Flags]
    public enum StageStar
    {
        stage1Star1 = 1 << 0,
        stage1Star2 = 1 << 1,
        stage1Star3 = 1 << 2,

        stage2Star1 = 1 << 3,
        stage2Star2 = 1 << 4,
        stage2Star3 = 1 << 5,

        stage3Star1 = 1 << 6,
        stage3Star2 = 1 << 7,
        stage3Star3 = 1 << 8,

        stage4Star1 = 1 << 9,
        stage4Star2 = 1 << 10,
        stage4Star3 = 1 << 11,

        stage5Star1 = 1 << 12,
        stage5Star2 = 1 << 13,
        stage5Star3 = 1 << 14,
    }
}
