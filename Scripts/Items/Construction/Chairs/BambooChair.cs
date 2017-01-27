namespace Server.Items
{
    [Furniture]
    [Flipable( 0xB5B, 0xB5A, 0xB5C, 0xB5D )]
    public class BambooChair : Item
    {
        [Constructable]
        public BambooChair() : base(0xB5B)
        {
            Weight = 20.0;
        }

        public BambooChair(Serial serial) : base(serial)
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