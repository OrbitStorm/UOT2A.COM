namespace Server.Items
{
    [Furniture]
    [Flipable( 0xB53, 0xB52, 0xB54, 0xB55 )]
    public class WoodenChairCushion : Item
    {
        [Constructable]
        public WoodenChairCushion() : base(0xB53)
        {
            Weight = 20.0;
        }

        public WoodenChairCushion(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if ( Weight == 6.0 )
                Weight = 20.0;
        }
    }
}